using System.Collections.Generic;
using UnityEngine;

namespace GunRun.Scripts
{
    public class Shotgun : WeaponBase
    {
        [SerializeField] private List<Transform> bulletSpawnPoints;

        public override void Shoot()
        {
            if (!CanShoot()) return;

            foreach (var spawnPoint in bulletSpawnPoints)
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                bullet.rigidbody.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}