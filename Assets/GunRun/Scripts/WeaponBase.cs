using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GunRun.Scripts
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected float shootRate = 0.5f;
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected float bulletForce = 10f;
        [SerializeField] protected float bulletLifetime = 10f;
        protected DateTime _lastShootTime;
        
        public abstract void Shoot();
        
        protected bool CanShoot()
        {
            var timeSinceLastShoot = DateTime.Now - _lastShootTime;
            var canShoot = timeSinceLastShoot.TotalSeconds >= shootRate;
            if (canShoot) _lastShootTime = DateTime.Now;
            return canShoot;
        }
    }
}