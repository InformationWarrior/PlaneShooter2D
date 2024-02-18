using TMPro;
using UnityEngine;
namespace PlaneShooter
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject pauseMenuPanel;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject gameOverPanel;

        private bool pauseStatus;

        private void Start()
        {
            pauseStatus = false;
            UpdateUIOnPause(pauseStatus);
            GameOver(false);
        }
        public void DisplayScoreText(int score)
        {
            scoreText.text = score.ToString();
        }

        public void PauseGame()
        {
            pauseStatus = !pauseStatus;
            UpdateUIOnPause(pauseStatus);
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            pauseStatus = false;
            UpdateUIOnPause(pauseStatus);
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void GameOver(bool status)
        {
            gameOverPanel.SetActive(status);
            pauseButton.SetActive(!status);
        }

        private void UpdateUIOnPause(bool pause)
        {
            pauseMenuPanel.SetActive(pause);
            pauseButton.SetActive(!pause);
        }
    }
}