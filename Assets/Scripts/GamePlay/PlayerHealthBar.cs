using UnityEngine;
using UnityEngine.UI;

namespace PlaneShooter
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image bar;

        private void Start()
        {
            SetBarValue(1f);
        }

        public void SetBarValue(float amount)
        {            
            bar.fillAmount = amount;
        }
    }
}