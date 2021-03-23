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
    public bool gameEnded = false;
    [Header("Ready Quest Played Data")]
    [SerializeField]
    public List<int> questPlayed;

    private void Awake()
    {
        questUI = FindObjectOfType<QuestUI>();
    }

    private void Start()
    {
    }
    
    private void Update()
    {
        if (GameManager.Instance.actualLevel == GameManager.Instance.limitLevel)
        {
            gameEnded = true;
            answerEvents.OnQuestionCompletedCallback();
        }
    }

    public void SelectAnswer(int answerIndex)
    {
        if (questManager.quests[randomQuestSelected].correctAnswer.Equals(answerIndex) && !gameEnded)
            answerEvents.OnAnswerAssertCallback();
        else
            answerEvents.OnAnswerErrorCallback();
    }

    public int returnQuest(QuestDifficulty difficulty) {
        List<Quest> questsSelectedByDifficulty = questManager.quests.FindAll(x => x.questDifficulty.Equals(difficulty));
        int questSelected = Random.Range(0, questsSelectedByDifficulty.Count);
        for (int i = 0; i < questPlayed.Count; i++)
        {
            if (questSelected != questPlayed[i])
                break;
        }
        Debug.Log($"Quests selected for {difficulty} difficulty {questsSelectedByDifficulty.Count}");
        return questSelected;
    }
}
