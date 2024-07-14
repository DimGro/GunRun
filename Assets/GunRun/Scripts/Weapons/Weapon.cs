using UnityEngine;

namespace GunRun.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Use();
        public abstract void Equip();
        public abstract void Unequip();
    }
}