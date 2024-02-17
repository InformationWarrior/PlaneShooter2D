using UnityEngine;

namespace PlaneShooter
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;

        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
    }
}