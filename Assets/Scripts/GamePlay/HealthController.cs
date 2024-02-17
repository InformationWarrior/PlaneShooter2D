using UnityEngine;

namespace PlaneShooter
{
    public abstract class HealthController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private GameObject damageEffectPrefab;

        protected GameObject explosion;
        protected GameObject damageEffect;

        protected abstract float InitialHealth { get; }
        protected abstract float ExplosionEndTime { get; }
        protected const float damageEffectEndTime = 0.05f;
        private const float InitialBarSize = 1f;
        protected float Damage;

        protected float health;
        protected float barSize;

        private void Start()
        {
            health = InitialHealth;
            barSize = InitialBarSize;
            Damage = InitialBarSize / InitialHealth;
        }

        protected abstract void OnTriggerEnter2D(Collider2D collision);

        protected abstract void DamageHealthBar();

        protected void DestroyOnZeroHealth()
        {
            Destroy(gameObject);
            PlayExplosionEffect();
            Destroy(explosion, ExplosionEndTime);
        }

        private void PlayExplosionEffect()
        {
            explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        protected void PlayBulletDamageEffect(Collider2D collision)
        {
            damageEffect = Instantiate(damageEffectPrefab, collision.transform.position, Quaternion.identity);
        }

        protected void DestroyBulletDamageEffect(float time)
        {
            Destroy(damageEffect, time);
        }
    }
}