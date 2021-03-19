using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int ActualPoints = 0;

    public void AddPoints(int points)
    {
        ActualPoints += points;
    }
}
