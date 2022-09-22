using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private Text textObject;

    private float countup = 0.0f;

    protected void Update()
    {
        this.countup += Time.deltaTime;

        if(this.countup >= 2.0f) {
            Destroy(this.gameObject);
            return;
        }

        if(this.countup >= 0.5f) {
            var color = this.textObject.color;
            color.a = color.a - 1.0f * Time.deltaTime;
            this.textObject.color = color;
        }

        this.transform.Translate(0f, 0.5f * Time.deltaTime, 0f);
    }

    public void Set(int score)
    {
        this.textObject.text = String.Format("+{0}pt", score);
    }
}
