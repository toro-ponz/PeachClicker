using UnityEngine;

namespace Clicker
{
    public class SquareBehavior : MonoBehaviour
    {
        private GameObject scorePrefab = null;

        [SerializeField] private GameObject squareScorePrefab;

        private readonly System.Random r = new System.Random();

        private float totalFlameTime = 0.0f;

        protected void Update()
        {
            this.totalFlameTime += Time.deltaTime;

            if (this.totalFlameTime >= 2.5f)
            {
                var score = this.CalcScore();
                this.AddScore(score);
                this.ShowScore(score);
                Destroy(this.gameObject);
                return;
            }

            if (this.totalFlameTime >= 1.0f)
            {
                return;
            }

            this.transform.Rotate(0, 0, 2.0f);
        }

        public void Set(GameObject scorePrefab)
        {
            this.scorePrefab = scorePrefab;
        }

        private int CalcScore()
        {
            return this.r.Next(1, 360);
        }

        private void AddScore(int score)
        {
            var behavior = this.scorePrefab.GetComponent<ScoreBehavior>();

            if (behavior is null)
            {
                Debug.Log("ScoreBehavior is null at SquareBehavior.addScore().");
                return;
            }

            behavior.AddScore(score);
        }

        private void ShowScore(int score)
        {
            var gameObject = Instantiate(
                this.squareScorePrefab,
                this.transform.position + new Vector3(0f, 0.75f, 0),
                Quaternion.identity,
                this.transform.parent.transform
            );

            var behavior = gameObject.GetComponent<SquareScoreBehavior>();

            if (behavior is null)
            {
                Debug.Log("SquareScoreBehavior is null at SquareBehavior.showScore().");
                return;
            }

            behavior.Set(score);
        }
    }
}
