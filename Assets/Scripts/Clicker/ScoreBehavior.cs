using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class ScoreBehavior : MonoBehaviour
    {
        [SerializeField] private Text scoreTextObject;

        [SerializeField] private long totalScore = 0L;

        private bool isFinished = false;

        public void AddScore(int score)
        {
            if (this.isFinished)
            {
                return;
            }

            this.totalScore += score;
            this.scoreTextObject.text = $"SCORE: {this.totalScore}pt";
        }

        public void Restart()
        {
            this.isFinished = false;
            this.totalScore = 0L;
            this.scoreTextObject.text = $"SCORE: {this.totalScore}pt";
        }

        public void Finish()
        {
            this.isFinished = true;
        }
    }
}
