using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    private QuestGameManager gameQuestManager;
    public Points PlayerPoints;

    // Start is called before the first frame update
    void Start()
    {
        gameQuestManager = FindObjectOfType<QuestGameManager>();
        PlayerPoints = FindObjectOfType<Points>();

        gameQuestManager.answerEvents.OnAnswerAssert += AnswerEvents_OnAnswerAssert;
        gameQuestManager.answerEvents.OnAnswerError += AnswerEvents_OnAnswerError;
    }

    private void AnswerEvents_OnAnswerError()
    {
        Debug.Log("Fallido");
    }

    private void AnswerEvents_OnAnswerAssert()
    {
        PlayerPoints.AddPoints(1000);
        Debug.Log("Correcto!");
        Debug.Log($"Puntaje: {PlayerPoints.ActualPoints}");
        gameQuestManager.NextLevel();
    }

}
