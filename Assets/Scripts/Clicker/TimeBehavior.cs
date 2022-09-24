using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class TimeBehavior : MonoBehaviour
    {
        [SerializeField] private Text timeTextObject;

        private float totalFlameTime = 0.0f;

        protected void Update()
        {
            this.totalFlameTime += Time.deltaTime;

            if (this.IsFinished())
            {
                this.timeTextObject.text = "TIME: FINISHED";
                return;
            }

            this.timeTextObject.text = $"TIME: {this.totalFlameTime}";
        }

        public void Begin()
        {
            this.totalFlameTime = 0.0f;
        }

        public bool IsFinished()
        {
            return this.totalFlameTime >= 60.0f;
        }
    }
}
