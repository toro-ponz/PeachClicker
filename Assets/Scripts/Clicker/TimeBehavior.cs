using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBehavior : MonoBehaviour
{
    [SerializeField]
    private Text timeTextObject;

    private float countup = 0.0f;

    protected void Update()
    {
        this.countup += Time.deltaTime;

        if(this.IsFinished()) {
            this.timeTextObject.text = String.Format("TIME: FINISHED");
            return;
        }

        this.timeTextObject.text = String.Format("TIME: {0}", this.countup);
    }

    public void Begin()
    {
        this.countup = 0.0f;
    }

    public bool IsFinished()
    {
        return this.countup >= 60.0f;
    }
}
