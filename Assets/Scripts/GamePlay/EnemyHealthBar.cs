using UnityEngine;

namespace PlaneShooter
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Transform bar;

        protected virtual void Start()
        {
            SetBarSize(1f);
        }
        public void SetBarSize(float size)
        {
            bar.localScale = new Vector2(size, 1f);
        }
    }
}