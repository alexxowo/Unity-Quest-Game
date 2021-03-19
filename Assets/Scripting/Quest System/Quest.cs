using System.Collections.Generic;
using Assets.Scripting.Quest_System;

public class Quest
{
    public int ID;
    public string Question;
    public Dictionary<int, string> Answers = new Dictionary<int, string>();
    public int correctAnswer = 0;
    public QuestDifficulty questDifficulty = QuestDifficulty.Very_Low;

    public Quest(int ID, string Question, Dictionary<int, string> Answers, int correctAnswer, QuestDifficulty questDifficulty)
    {
        this.ID = ID;
        this.Question = Question;
        this.Answers = Answers;
        this.correctAnswer = correctAnswer;
        this.questDifficulty = questDifficulty;
    }
    public Quest() { }
}