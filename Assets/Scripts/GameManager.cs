using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlaneShooter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private AudioManager _audioManager;

        public UIManager UIManager { get => _uiManager; }
        public AudioManager AudioManager { get => _audioManager; }

        private int level;

        public static GameManager Instance = null;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoad;

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void StartGame()
        {
            LoadScene(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            _uiManager = FindAnyObjectByType<UIManager>();
        }

        private void LoadScene(int level)
        {
            this.level = level;
            SceneManager.LoadScene("Level" + level);
        }
    }
}