using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneShooter
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyAircraft;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Transform parent;
        private float minX;
        private float maxX;
        private float padding = 0.8f;
        private readonly WaitForSeconds delay = new WaitForSeconds(3f);

        private void Start()
        {
            (minX, maxX) = playerMovement.FindBoundaryXAxis(Camera.main, padding);
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                yield return delay;

                int index = GetRandomNumber(enemyAircraft.Length);

                Instantiate(enemyAircraft[index], GetRandomPosition(), Quaternion.identity, parent);
            }
        }

        private Vector3 GetRandomPosition()
        {
            float XPos = Random.Range(minX, maxX);
            return new Vector3(XPos,transform.position.y);
        }

        private int GetRandomNumber(int range)
        {
            return Random.Range(0, range);
        }
    }
}