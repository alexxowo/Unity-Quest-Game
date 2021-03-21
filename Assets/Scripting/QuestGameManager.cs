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
    public int[] questPlayed;

    private void Start()
    {
        Debug.Log($"Selected Quest Index {returnQuest(QuestDifficulty.Low)}");
    }

    public void SelectAnswer(int answerIndex)
    {
        if (questManager.quests[randomQuestSelected].correctAnswer.Equals(answerIndex))
            answerEvents.OnAnswerAssertCallback();
        else
            answerEvents.OnAnswerErrorCallback();
    }

    public int returnQuest(QuestDifficulty difficulty) {
        List<Quest> questsSelectedByDifficulty = questManager.quests.FindAll(x => x.questDifficulty.Equals(difficulty));
        int questSelected = Random.Range(0, questsSelectedByDifficulty.Count);
        Debug.Log($"Quests selected for {difficulty} difficulty {questsSelectedByDifficulty.Count}");
        return questSelected;
    }
}
