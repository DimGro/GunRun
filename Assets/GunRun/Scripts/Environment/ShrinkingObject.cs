using UnityEngine;

namespace GunRun.Scripts
{
    public class ShrinkingObject : MonoBehaviour
    {
        [SerializeField] private float shrinkPerImpact = 0.2f;
        [SerializeField] private float destroyScale = 0.1f;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Projectile")) return;
            transform.localScale -= 0.2f * Vector3.one;
            if (transform.localScale.x <= destroyScale || transform.localScale.y <= destroyScale) Destroy(gameObject);
        }
    }
}