using System;
using System.Collections.Generic;
using UnityEngine;


namespace GunRun.Scripts
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private List<WeaponBase> weapons;
        private WeaponBase _currentWeapon;
        private int _currentWeaponIndex = -1;
        
        private void Awake()
        {
            EquipWeapon(0);
        }
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _currentWeapon.Shoot();
            }
            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                EquipNextWeapon();
            }
        }

        private void EquipNextWeapon()
        {
            var nextWeaponIndex = _currentWeaponIndex + 1;
            if (nextWeaponIndex > weapons.Count - 1) nextWeaponIndex = 0;
            EquipWeapon(nextWeaponIndex);
        }

        private void EquipWeapon(int weaponIndex)
        {
            if (_currentWeaponIndex == weaponIndex) return;

            _currentWeapon?.gameObject.SetActive(false);
            
            _currentWeaponIndex = weaponIndex;
            _currentWeapon = weapons[weaponIndex];
            _currentWeapon.gameObject.SetActive(true);
        }
    }
}