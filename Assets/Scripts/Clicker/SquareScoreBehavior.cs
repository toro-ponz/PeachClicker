using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class SquareScoreBehavior : MonoBehaviour
    {
        [SerializeField] private Text textObject;

        private float totalFlameTime = 0.0f;

        protected void Update()
        {
            this.totalFlameTime += Time.deltaTime;

            if (this.totalFlameTime >= 2.0f)
            {
                Destroy(this.gameObject);
                return;
            }

            if (this.totalFlameTime >= 0.5f)
            {
                var color = this.textObject.color;
                color.a = color.a - (1.0f * Time.deltaTime);
                this.textObject.color = color;
            }

            this.transform.Translate(0f, 0.5f * Time.deltaTime, 0f);
        }

        public void Set(int score)
        {
            this.textObject.text = $"+{score}pt";
        }
    }
}
