using System;
using System.Collections.Generic;
using UnityEngine;

namespace GunRun.Scripts
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private List<Transform> bulletSpawnPoints;
        [SerializeField] protected float shootRate = 0.5f;
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected float bulletForce = 10f;
        [SerializeField] protected float bulletLifetime = 10f;
        protected DateTime _lastShootTime;
        
        public virtual void Shoot()
        {
            if (!CanShoot()) return;

            foreach (var spawnPoint in bulletSpawnPoints)
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                bullet.rigidbody.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        
        protected bool CanShoot()
        {
            var timeSinceLastShoot = DateTime.Now - _lastShootTime;
            var canShoot = timeSinceLastShoot.TotalSeconds >= shootRate;
            if (canShoot) _lastShootTime = DateTime.Now;
            return canShoot;
        }
        
    }
}