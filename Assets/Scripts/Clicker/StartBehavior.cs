using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreGameObject;
    [SerializeField]
    private GameObject timeGameObject;

    [SerializeField]
    private Button buttonObject;

    protected void Start()
    {
        this.buttonObject.onClick.AddListener(this.OnClick);
    }

    protected void Update()
    {
        if (this.isFinished()) {
            this.notifyFinish();
        }
    }

    protected void OnClick()
    {
        this.restartScore();
        this.restartTime();
    }

    private bool isFinished()
    {
        return this.getTimeBehavior()?.IsFinished() ?? false;
    }

    private void notifyFinish()
    {
        this.getScoreBehavior()?.Finish();
    }

    private void restartScore()
    {
        this.getScoreBehavior()?.Restart();
    }

    private void restartTime()
    {
        this.getTimeBehavior()?.Begin();
    }

    private ScoreBehavior? getScoreBehavior()
    {
        ScoreBehavior behavior = this.scoreGameObject.GetComponent<ScoreBehavior>();

        if (behavior == null) {
            Debug.Log("ScoreBehavior is null at StartBehavior.getScoreBehavior().");
        }

        return behavior;
    }

    private TimeBehavior? getTimeBehavior()
    {
        TimeBehavior behavior = this.timeGameObject.GetComponent<TimeBehavior>();

        if (behavior == null) {
            Debug.Log("TimeBehavior is null at StartBehavior.getTimeBehavior().");
        }

        return behavior;
    }
}
