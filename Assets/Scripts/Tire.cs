using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tire : MonoBehaviour
    {
        [SerializeField] private TireType tireType;
        [SerializeField] private Rigidbody2D rigidbody;
        public Action<TireType, bool> OnStateUpdate;

        private bool _isGrounded = true;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (!_isGrounded)
                {
                    _isGrounded = true;
                    OnStateUpdate?.Invoke(tireType, _isGrounded);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;
                OnStateUpdate?.Invoke(tireType, _isGrounded);
            }
        }

        public void AddTorque(float torque)
        {
            rigidbody.AddTorque(torque);
        }

        public enum TireType
        {
            LeftTire,
            RightTire
        }
    }
}
