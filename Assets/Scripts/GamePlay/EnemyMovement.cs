using UnityEngine;

namespace PlaneShooter
{
    public class EnemyMovement : MonoBehaviour
    {
        private readonly float speed = 1f;

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down);
        }
    }
}