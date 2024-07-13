using UnityEngine;

namespace GunRun.Scripts
{
    public class Pistol : WeaponBase
    {
        [SerializeField] private Transform bulletSpawnPoint;
        
        public override void Shoot()
        {
            if (!CanShoot()) return;
            
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.rigidbody.AddForce(Vector2.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}