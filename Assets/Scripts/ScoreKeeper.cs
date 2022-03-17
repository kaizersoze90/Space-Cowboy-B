using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;

    public int GetScore()
    {
        return currentScore;
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

}
