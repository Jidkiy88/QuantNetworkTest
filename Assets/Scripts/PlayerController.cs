using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scripts.Tire;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D carRB;
        [SerializeField] private CollisionDetector headDetector;
        [SerializeField] private List<Tire> tires;

        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        private float _currentSpeed;
        private float _currentRotationSpeed;

        private bool _isAlive = true;

        private bool _isLeftTireGrounded = true;
        private bool _isRightTireGrounded = true;

        private void Awake()
        {
            headDetector.OnCollision += OnDeath;
            tires.ForEach(t => t.OnStateUpdate += CheckState);
        }

        private void OnDestroy()
        {
            headDetector.OnCollision -= OnDeath;
        }

        private void Update()
        {
            if (_isAlive)
            {
                if (IsGrounded())
                {
                    tires.ForEach(t => t.AddTorque(_currentSpeed * Time.deltaTime));
                    carRB.AddTorque(_currentRotationSpeed * Time.deltaTime);
                }
            }
        }

        public void OnButtonDown(int direction)
        {
            _currentSpeed = speed * direction;
            _currentRotationSpeed = rotationSpeed * direction;
        }

        public void OnButtonUp()
        {
            _currentSpeed = 0f;
            _currentRotationSpeed = 0f;
        }

        private bool IsGrounded()
        {
            if (!_isLeftTireGrounded && !_isRightTireGrounded)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CheckState(TireType type, bool state)
        {
            if (type == TireType.LeftTire)
            {
                _isLeftTireGrounded = state;
            }
            else
            {
                _isRightTireGrounded = state;
            }

            
        }

        private void OnDeath(string objectTag)
        {
            if (objectTag != "Ground")
            {
                return;
            }

            headDetector.OnCollision -= OnDeath;
            _isAlive = false;
        }
    }
}
