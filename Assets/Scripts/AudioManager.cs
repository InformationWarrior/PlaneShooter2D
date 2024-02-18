using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneShooter
{
    [Serializable]
    class Sound
    {
        public string Name;
        public AudioClip clip;
    }
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<Sound> sounds;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}