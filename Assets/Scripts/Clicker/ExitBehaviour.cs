using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class ExitBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Button buttonObject;

        protected void Start()
        {
            this.buttonObject.onClick.AddListener(OnClick);
        }

        private static void OnClick()
        {
            Application.Quit();
        }
    }
}
