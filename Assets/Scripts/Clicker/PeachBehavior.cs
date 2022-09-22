using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachBehavior : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer peachRenderer;

    [SerializeField]
    private Sprite lightSprite;
    [SerializeField]
    private Sprite darkSprite;
    private bool isDark = false;

    [SerializeField]
    private GameObject scorePrefab;
    [SerializeField]
    private GameObject squarePrefab;

    private readonly System.Random r = new System.Random();

    protected void OnMouseOver()
    {
        // on left click
        if (Input.GetMouseButtonDown(0)) {
            this.toggle();
            this.throwDice();
        }
    }

    private void toggle()
    {
        if (this.isDark) {
            this.peachRenderer.sprite = this.lightSprite;
            this.isDark = false;
        }
        else {
            this.peachRenderer.sprite = this.darkSprite;
            this.isDark = true;
        }
    }

    private void throwDice()
    {
        var gameObject = Instantiate(
            this.squarePrefab,
            this.transform.position + new Vector3(((float)(this.r.Next(-150, 150)) / 100), -1.5f, 0),
            this.transform.rotation * new Quaternion(this.r.Next(0, 360), 0, 0, 1),
            this.transform.parent.transform
        );

        SquareBehavior behavior = gameObject.GetComponent<SquareBehavior>();

        if (behavior == null) {
            Debug.Log("SquareBehavior is null at PeachBehavior.ThrowDice().");
            return;
        }

        behavior.Set(this.scorePrefab);
    }
}
