using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int actualLevel = 0;
    QuestGameManager questGameManager;

    private void Awake()
    {
        questGameManager = FindObjectOfType<QuestGameManager>();

        questGameManager.answerEvents.OnAnswerAssert += AnswerEvents_OnAnswerAssert;
        questGameManager.answerEvents.OnAnswerError += AnswerEvents_OnAnswerError;
    }

    private void AnswerEvents_OnAnswerError()
    {
        throw new System.NotImplementedException();
    }

    private void AnswerEvents_OnAnswerAssert()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {

    }
}
