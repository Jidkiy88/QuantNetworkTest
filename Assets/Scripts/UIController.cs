using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartScene);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
