using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerEvents{
    public delegate void OnAnswerAssetDelegate();
    public event OnAnswerAssetDelegate OnAnswerAssert;

    public delegate void OnAnswerErrorDelegate();
    public event OnAnswerErrorDelegate OnAnswerError;

    public delegate void OnQuestionsCompleteDelegate();
    public event OnQuestionsCompleteDelegate OnQuestionCompleted;

    public void OnQuestionCompletedCallback() => OnQuestionCompleted.Invoke();
    public void OnAnswerAssertCallback() => OnAnswerAssert.Invoke();
    public void OnAnswerErrorCallback() => OnAnswerError.Invoke();

    
}
