using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBehaviour : MonoBehaviour
{
    [SerializeField]
    private Button buttonObject;

    protected void Start()
    {
        this.buttonObject.onClick.AddListener(this.OnClick);
    }

    protected void OnClick()
    {
        UnityEngine.Application.Quit();
    }
}
