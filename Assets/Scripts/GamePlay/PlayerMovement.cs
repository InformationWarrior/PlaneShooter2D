using UnityEngine;

namespace PlaneShooter
{
    public class PlayerMovement : MonoBehaviour
    {
        private float minX;
        private float maxX;

        private float minY;
        private float maxY;

        private readonly float speed = 10f;
        private readonly float padding = 0.8f;

        private void Start()
        {
            FindBoundaries();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void FindBoundaries()
        {
            Camera mainCamera = Camera.main;

            (minX, maxX) = FindBoundaryXAxis(mainCamera, padding);
            FindBoundaryYAxis(mainCamera, padding);
        }

        public (float, float) FindBoundaryXAxis(Camera camera, float padding)
        {
            return (camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding,
            camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding);
        }

        private void FindBoundaryYAxis(Camera camera, float padding)
        {
            minY = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
            maxY = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        }

        private void MovePlayer()
        {
            float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

            float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);

            transform.position = new Vector2(newXPos, newYPos);
        }
    }
}