using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GunRun.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float moveSpeed = 5f;
        private Vector2 _moveDirection;

        private void Update()
        {
            _moveDirection.x = Input.GetAxisRaw("Horizontal");
            _moveDirection.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            rigidbody.MovePosition(rigidbody.position + _moveDirection * moveSpeed);
        }
    }
}