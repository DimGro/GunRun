using UnityEngine;

namespace GunRun.Scripts
{
    public class ColorChangingObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Projectile")) return;
            spriteRenderer.color = Random.ColorHSV();
        }
    }
}