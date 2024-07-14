using UnityEngine;

namespace GunRun.Scripts
{
    public class DestroyableObject : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Projectile")) return;
            Destroy(gameObject);
        }
    }
}