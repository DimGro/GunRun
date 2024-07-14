using System;
using System.Collections.Generic;
using UnityEngine;

namespace GunRun.Scripts
{
    public abstract class ShootingWeapon : Weapon
    {
        [SerializeField] private List<Transform> bulletSpawnPoints;
        [SerializeField] private ShootingWeaponConfig config;
        private DateTime _lastShootTime;
        
        public override void Use()
        {
            Shoot();
        }

        public override void Equip()
        {
            gameObject.SetActive(true);
        }

        public override void Unequip()
        {
            gameObject.SetActive(false);
        }
        
        protected virtual void Shoot()
        {
            if (!CanShoot()) return;

            foreach (var spawnPoint in bulletSpawnPoints)
            {
                var bullet = Instantiate(config.bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                bullet.rigidbody.AddForce(spawnPoint.up * config.bulletForce, ForceMode2D.Impulse);
                if (config.bulletLifetime > 0) bullet.DestroyAfterTime(config.bulletLifetime);
            }
        }

        private bool CanShoot()
        {
            var timeSinceLastShoot = DateTime.Now - _lastShootTime;
            var canShoot = timeSinceLastShoot.TotalSeconds >= config.shootRate;
            if (canShoot) _lastShootTime = DateTime.Now;
            return canShoot;
        }
    }
}