using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerEvents{
    public delegate void OnAnswerAssetDelegate();
    public event OnAnswerAssetDelegate OnAnswerAssert;

    public delegate void OnAnswerErrorDelegate();
    public event OnAnswerErrorDelegate OnAnswerError;

    public void OnAnswerAssertCallback() => OnAnswerAssert.Invoke();
    public void OnAnswerErrorCallback() => OnAnswerError.Invoke();
}
