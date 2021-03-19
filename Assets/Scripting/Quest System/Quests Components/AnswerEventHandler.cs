using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerEventHandler : MonoBehaviour
{
    private QuestGameManager questGameManager;

    private void Awake() => questGameManager = FindObjectOfType<QuestGameManager>();

    public void SelectAnswers(int answerSelected) => questGameManager.SelectAnswer(answerSelected);
}
