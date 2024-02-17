using UnityEngine;

namespace PlaneShooter
{
    public class BackgroundScroll : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        public float speed = 0.1f;

        private void Update()
        {
            SetMaterialOffsetValue();
        }

        private void SetMaterialOffsetValue()
        {
            meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
        }
    }
}