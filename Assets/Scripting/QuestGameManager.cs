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
    [SerializeField]
    public List<int> questPlayed;

    private void Start()
    {
        randomQuestSelected = Random.Range(0, questManager.quests.Count);
        questUI.setupUI(randomQuestSelected, questManager);
        questUI.setPointsLabel(0);
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
                questUI.setupUI(randomQuestSelected, questManager);
                break;
            }
        }
    }

}
