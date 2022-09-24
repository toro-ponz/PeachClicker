using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class StartBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject scoreGameObject;
        [SerializeField] private GameObject timeGameObject;

        [SerializeField] private Button buttonObject;

        protected void Start()
        {
            this.buttonObject.onClick.AddListener(this.OnClick);
        }

        protected void Update()
        {
            if (this.IsFinished())
            {
                this.NotifyFinish();
            }
        }

        private void OnClick()
        {
            this.RestartScore();
            this.RestartTime();
        }

        private bool IsFinished()
        {
            return this.GetTimeBehavior()?.IsFinished() ?? false;
        }

        private void NotifyFinish()
        {
            this.GetScoreBehavior()?.Finish();
        }

        private void RestartScore()
        {
            this.GetScoreBehavior()?.Restart();
        }

        private void RestartTime()
        {
            this.GetTimeBehavior()?.Begin();
        }

        private ScoreBehavior GetScoreBehavior()
        {
            var behavior = this.scoreGameObject.GetComponent<ScoreBehavior>();

            if (behavior is null)
            {
                Debug.Log("ScoreBehavior is null at StartBehavior.GetScoreBehavior().");
                return null;
            }

            return behavior;
        }

        private TimeBehavior GetTimeBehavior()
        {
            var behavior = this.timeGameObject.GetComponent<TimeBehavior>();

            if (behavior is null)
            {
                Debug.Log("TimeBehavior is null at StartBehavior.GetTimeBehavior().");
                return null;
            }

            return behavior;
        }
    }
}
