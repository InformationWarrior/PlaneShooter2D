using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlaneShooter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private SceneLoader _sceneLoader;
        public UIManager UIManager { get => _uiManager; }
        public static GameManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _sceneLoader = FindAnyObjectByType<SceneLoader>();
        }

        public void LoadScene()
        {
            if (_sceneLoader != null)
                Instance._sceneLoader.Reload();
        }
    }
}