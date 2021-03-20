using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Modules
    private QuestGameManager gameQuestManager;
    public Points PlayerPoints;

    [Header("Player Stats")]
    public int actualLevel = 0;
    public int limitLevel = 10;
    
    // Singleton
    private static GameManager _instance { get; set; }
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

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
        if (actualLevel == limitLevel) 
        {
            Debug.Log("Listo!");
        }
        else
        {
            PlayerPoints.AddPoints(1000);
            gameQuestManager.questUI.setPointsLabel(1000);
            Debug.Log($"Puntaje: {PlayerPoints.ActualPoints}");
            gameQuestManager.NextLevel();
        }
    }

}
