using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    private GameObject scorePrefab = null;

    [SerializeField]
    private GameObject squareScorePrefab;

    private readonly System.Random r = new System.Random();

    private float countup = 0.0f;

    protected void Update()
    {
        this.countup += Time.deltaTime;

        if(this.countup >= 2.5f) {
            var score = this.calcScore();
            this.addScore(score);
            this.showScore(score);
            Destroy(this.gameObject);
            return;
        }

        if(this.countup >= 1.0f) {
            return;
        }

        this.transform.Rotate(0, 0, 2.0f);
    }

    public void Set(GameObject scorePrefab)
    {
        this.scorePrefab = scorePrefab;
    }

    private int calcScore()
    {
        return this.r.Next(1, 360);
    }

    private void addScore(int score)
    {
        ScoreBehavior behavior = this.scorePrefab.GetComponent<ScoreBehavior>();

        if (behavior == null) {
            Debug.Log("ScoreBehavior is null at SquareBehavior.addScore().");
            return;
        }

        behavior?.AddScore(score);
    }

    private void showScore(int score)
    {
        var gameObject = Instantiate(
            this.squareScorePrefab,
            this.transform.position + new Vector3(0f, 0.75f, 0),
            Quaternion.identity,
            this.transform.parent.transform
        );

        SquareScoreBehavior behavior = gameObject.GetComponent<SquareScoreBehavior>();

        if (behavior == null) {
            Debug.Log("SquareScoreBehavior is null at SquareBehavior.showScore().");
            return;
        }

        behavior.Set(score);
    }
}
