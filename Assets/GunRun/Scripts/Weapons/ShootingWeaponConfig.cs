using UnityEngine;

namespace GunRun.Scripts
{
    [CreateAssetMenu(fileName = "ShootingWeaponConfig", menuName = "ScriptableObjects/ShootingWeaponConfig")]
    public class ShootingWeaponConfig : ScriptableObject
    {
        public float shootRate = 0.5f;
        public Bullet bulletPrefab;
        public float bulletForce = 10f;
        public float bulletLifetime = 10f;
    }
}