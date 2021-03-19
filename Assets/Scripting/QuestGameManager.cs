using System.Collections;
using Assets.Scripting.Quest_System;
using System.Collections.Generic;
using UnityEngine;

public class QuestGameManager : MonoBehaviour
{
    [Header("Questions Management")]
    public QuestManager questManager;
    public AnswerEvents answerEvents = new AnswerEvents();
    public QuestUI questUI;
    // Quests internal settings
    int randomQuestSelected;
    [Header("Quests ready played data")]
    public List<int> questPlayed;

    //private void Awake() => questManager = FindObjectOfType<QuestManager>();

    private void Start()
    {
        initQuestForDebug();

        randomQuestSelected = Random.Range(0, questManager.quests.Count);
        questUI.setupUI(randomQuestSelected, questManager);
    }

    public void SelectAnswer(int answerIndex)
    {
        if (questManager.quests[randomQuestSelected].correctAnswer.Equals(answerIndex))
            answerEvents.OnAnswerAssertCallback();
        else
            answerEvents.OnAnswerErrorCallback();
    }

    public void NextLevel()
    {
        questPlayed.Add(randomQuestSelected);

        randomQuestSelected = Random.Range(0, questManager.quests.Count);
        
        for(int i = 0; i < questPlayed.Count; i++)
        {
            if (questPlayed[i] != randomQuestSelected) 
            {
                StartNewLevel();
                Debug.Log("Starting new level");
                break;
            }
        }
    }

    public void StartNewLevel()
    {
        questUI.setupUI(randomQuestSelected, questManager);
    }

    private void initQuestForDebug()
    {
        Dictionary<int, string> respuestasQuest1 = new Dictionary<int, string>();
        respuestasQuest1.Add(0, "1914");
        respuestasQuest1.Add(1, "1944");
        respuestasQuest1.Add(2, "1988");
        respuestasQuest1.Add(3, "1865");
        Quest quest1 = new Quest(0, "En que anho fue la primera guerra mundial", respuestasQuest1, 0, QuestDifficulty.Mid);

        Dictionary<int, string> respuestasQuest2 = new Dictionary<int, string>();
        respuestasQuest2.Add(0, "1960");
        respuestasQuest2.Add(1, "1945");
        respuestasQuest2.Add(2, "2021");
        respuestasQuest2.Add(3, "1889");
        Quest quest2 = new Quest(0, "En que anho fue fundada la ONU?", respuestasQuest2, 1, QuestDifficulty.Mid);

        Dictionary<int, string> respuestasQuest3 = new Dictionary<int, string>();
        respuestasQuest3.Add(0, "Simon Rodriguez");
        respuestasQuest3.Add(1, "George Washintong");
        respuestasQuest3.Add(2, "Simon Bolivar");
        respuestasQuest3.Add(3, "Fidel Castro");
        Quest quest3 = new Quest(0, "Quien fue el libertador de Venezuela y Americalatina", respuestasQuest3, 2, QuestDifficulty.Mid);

        questManager.quests.Add(quest1);
        questManager.quests.Add(quest2);
        questManager.quests.Add(quest3);
    }

}
