using System.Collections.Generic;
using Assets.Scripting.Quest_System;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Quest
{
    [SerializeField]
    public int ID; 
    [SerializeField]
    public string Question;
    [FormerlySerializedAs("Answers")]
    [SerializeField]
    public List<Answer> Answers = new List<Answer>();
    //public Dictionary<int, string> Answers = new Dictionary<int, string>();
    [SerializeField]
    public int correctAnswer = 0;
    [SerializeField]
    public QuestDifficulty questDifficulty = QuestDifficulty.Very_Low;

    public Quest(int ID, string Question, List<Answer> Answers, int correctAnswer, QuestDifficulty questDifficulty)
    {
        this.ID = ID;
        this.Question = Question;
        this.Answers = Answers;
        this.correctAnswer = correctAnswer;
        this.questDifficulty = questDifficulty;
    }
    public Quest() { }
}