using UnityEngine;
using UnityEngine.SceneManagement;

namespace Credit
{
    public class CreditBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject timeGameObject;

        private float totalFlameTime = 0.0f;

        protected void Update()
        {
            this.totalFlameTime += Time.deltaTime;

            if (this.totalFlameTime >= 3.5f)
            {
                this.StartClicker();
            }
        }

        private void StartClicker()
        {
            SceneManager.LoadSceneAsync("Scenes/ClickerScene");
        }
    }
}
