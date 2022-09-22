using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private Text scoreTextObject;

    [SerializeField]
    private long score = 0L;

    private bool isFinished = false;

    public void AddScore(int score)
    {
        if (this.isFinished) {
            return;
        }

        this.score += score;
        this.scoreTextObject.text = String.Format("SCORE: {0}pt", this.score);
    }

    public long GetScore()
    {
        return this.score;
    }

    public void Restart()
    {
        this.isFinished = false;
        this.score = 0L;
        this.scoreTextObject.text = String.Format("SCORE: {0}pt", this.score);
    }

    public void Finish()
    {
        this.isFinished = true;
    }
}
