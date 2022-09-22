using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject timeGameObject;

    private float countup = 0.0f;

    protected void Update()
    {
        this.countup += Time.deltaTime;

        if(this.countup >= 3.5f) {
            this.StartClicker();
            return;
        }
    }

    private void StartClicker()
    {
        SceneManager.LoadSceneAsync("Scenes/ClickerScene");
    }
}
