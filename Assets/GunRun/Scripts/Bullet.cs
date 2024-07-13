using System;
using UnityEngine;

namespace GunRun.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rigidbody;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Projectile")) return;
            Destroy(gameObject);
        }
    }
}