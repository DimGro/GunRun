using System.Collections;
using UnityEngine;

namespace GunRun.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rigidbody;

        public void DestroyAfterTime(float seconds)
        {
            StartCoroutine(DestroyAfterTimeCoroutine(seconds));
        }

        private IEnumerator DestroyAfterTimeCoroutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Projectile")) return;
            Destroy(gameObject);
        }
    }
}