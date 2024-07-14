using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GunRun.Scripts
{
    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;
        [SerializeField] private PlayerInput playerInput;
        private InputAction _useWeaponAction;
        private InputAction _switchWeaponAction;
        private Weapon _currentWeapon;
        private int _currentWeaponIndex = -1;
        
        private void Awake()
        {
            _useWeaponAction = playerInput.actions["UseWeapon"];
            _switchWeaponAction = playerInput.actions["SwitchWeapon"];
            
            _useWeaponAction.performed += UseWeaponHandler;
            _switchWeaponAction.started += SwitchWeaponHandler;
            EquipWeapon(0);
        }

        private void SwitchWeaponHandler(InputAction.CallbackContext _)
        {
            EquipNextWeapon();
        }

        private void UseWeaponHandler(InputAction.CallbackContext _)
        {
            _currentWeapon.Use();
        }

        // private void Update()
        // {
        //     if (Input.GetKey(KeyCode.Mouse0))
        //     {
        //         _currentWeapon.Use();
        //     }
        //     
        //     if (Input.GetKeyDown(KeyCode.Mouse1))
        //     {
        //         EquipNextWeapon();
        //     }
        // }

        private void EquipNextWeapon()
        {
            var nextWeaponIndex = _currentWeaponIndex + 1;
            if (nextWeaponIndex > weapons.Count - 1) nextWeaponIndex = 0;
            EquipWeapon(nextWeaponIndex);
        }

        private void EquipWeapon(int weaponIndex)
        {
            if (_currentWeaponIndex == weaponIndex) return;

            _currentWeapon?.Unequip();
            
            _currentWeaponIndex = weaponIndex;
            _currentWeapon = weapons[weaponIndex];
            _currentWeapon.Equip();
        }
    }
}