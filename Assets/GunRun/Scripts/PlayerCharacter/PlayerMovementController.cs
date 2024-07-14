using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GunRun.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private InputAction moveAction;
        private Vector2 _moveDirection;

        private void Awake()
        {
            moveAction = playerInput.actions["Move"];
        }

        private void Update()
        {
            _moveDirection = moveAction.ReadValue<Vector2>();
            _moveDirection.Normalize();
        }

        private void FixedUpdate()
        {
            rigidbody.MovePosition(rigidbody.position + _moveDirection * moveSpeed);
        }
    }
}