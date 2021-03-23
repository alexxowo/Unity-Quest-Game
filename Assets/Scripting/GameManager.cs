using UnityEngine;
using Assets.Scripting.Quest_System;

public class GameManager : MonoBehaviour
{
    // Modules
    public QuestGameManager gameQuestManager;
    public Points PlayerPoints;

    private int randomSelectedQuest = 0;
    
    [Header("Player Stats")]
    public int actualLevel = 0;
    public int limitLevel = 12;
    
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

    private void Awake()
    {
        // Define modules
        gameQuestManager = FindObjectOfType<QuestGameManager>();
        PlayerPoints = FindObjectOfType<Points>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameQuestManager = FindObjectOfType<QuestGameManager>();
        PlayerPoints = FindObjectOfType<Points>();

        // Attach Events
        gameQuestManager.answerEvents.OnQuestionCompleted += OnGameCompleted;
        gameQuestManager.answerEvents.OnAnswerAssert += OnAnswerAssert;
        gameQuestManager.answerEvents.OnAnswerError += OnAnswerError;

        StartGame();
    }

    private void StartGame(){
        gameQuestManager.questUI.setupUI(gameQuestManager.returnQuest(QuestDifficulty.Low), gameQuestManager.questManager);
    }
    
    private void OnGameCompleted()
    {
        Debug.Log("Juego completado");
    }

    private void OnAnswerError()
    {
        Debug.Log("Respuesta Fallida");
    }

    private void OnAnswerAssert()
    {
        Debug.Log("Respuesta correcta");
        actualLevel++;
        gameQuestManager.questPlayed.Add(randomSelectedQuest);
        randomSelectedQuest = gameQuestManager.returnQuest(QuestDifficulty.Low);
        gameQuestManager.questUI.setupUI(randomSelectedQuest, gameQuestManager.questManager);

    }
}
