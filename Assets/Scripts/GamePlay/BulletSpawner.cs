using System.Collections;
using UnityEngine;

namespace PlaneShooter
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject muzzleFlash;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Transform bulletParent;
        [SerializeField] private Transform[] gunPoint;

        private readonly WaitForSeconds bulletDelay = new WaitForSeconds(1f);
        private readonly WaitForSeconds muzzleFlashDelay = new WaitForSeconds(0.04f);

        private void Start()
        {
            MuzzleFlash(false);
            StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                yield return bulletDelay;
                MuzzleFlash(true);
                ShootBullets();
                audioSource.Play();
                yield return muzzleFlashDelay;
                MuzzleFlash(false);
            }
        }

        private void ShootBullets()
        {
            for (int i = 0; i < gunPoint.Length; i++)
            {
                Instantiate(bullet, gunPoint[i].position, Quaternion.identity, bulletParent);
            }
        }

        private void MuzzleFlash(bool status)
        {
            muzzleFlash.SetActive(status);
        }
    }
}