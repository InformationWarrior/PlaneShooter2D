using UnityEngine;

namespace PlaneShooter
{
    public class PlayerHealth : HealthController
    {
        [SerializeField] private PlayerHealthBar playerHealthBar;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip damageClip;
        [SerializeField] private AudioClip explosionSound;
        private int score = 0;
        private const float playerHealth = 10f;
        private const float explosionEndTime = 2f;

        protected override float InitialHealth { get; } = playerHealth;

        protected override float ExplosionEndTime { get; } = explosionEndTime;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyBullet"))
            {
                audioSource.PlayOneShot(damageClip, 0.5f);
                DamageHealthBar();
                Destroy(collision.gameObject);
                PlayBulletDamageEffect(collision);
                DestroyBulletDamageEffect(damageEffectEndTime);

                if (health <= 0)
                {
                    AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                    GameManager.Instance.UIManager.GameOver(true);
                    DestroyOnZeroHealth();
                }
            }

            if (collision.CompareTag("Coin"))
            {
                Destroy(collision.gameObject);
                IncreaseScore();
            }
        }

        protected override void DamageHealthBar()
        {
            if (health > 0)
            {
                health--;
                barSize -= Damage;
                playerHealthBar.SetBarValue(barSize);
            }
        }

        private void IncreaseScore()
        {
            score++;
            DisplayScore(score);
        }

        private void DisplayScore(int score)
        {
            GameManager.Instance.UIManager.DisplayScoreText(score);
        }
    }
}