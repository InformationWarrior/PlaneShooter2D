using UnityEngine;

namespace PlaneShooter
{
    public class EnemyHealth : HealthController
    {
        [SerializeField] private EnemyHealthBar enemyHealthBar;
        [SerializeField] private GameObject coinPrefab;
        private const float enemyHealth = 5f;
        private const float explosionEndTime = 0.4f;

        protected override float InitialHealth { get; } = enemyHealth;
        protected override float ExplosionEndTime { get; } = explosionEndTime;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerBullet"))
            {
                DamageHealthBar();
                Destroy(collision.gameObject);
                PlayBulletDamageEffect(collision);
                DestroyBulletDamageEffect(damageEffectEndTime);

                if (health <= 0)
                {
                    SpawnCoin();
                    DestroyOnZeroHealth();
                }
            }
        }

        protected override void DamageHealthBar()
        {
            if (health > 0)
            {
                health--;
                barSize -= Damage;
                enemyHealthBar.SetBarSize(barSize);
            }
        }

        private void SpawnCoin()
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}