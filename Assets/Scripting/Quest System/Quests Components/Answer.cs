using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;

[System.Serializable]
public class Answer
{
    [SerializeField]
    public int AnswerID;
    [SerializeField]
    public string _Answer;

    [HideInInspector]
    public bool showAnswerContent = false;
    public Answer() { }

    public Answer(int answerID, string Answer)
    {
        this.AnswerID = answerID;
        this._Answer = Answer;
    }
}
