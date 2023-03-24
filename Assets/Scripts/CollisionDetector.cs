using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class CollisionDetector : MonoBehaviour
    {
        public Action<string> OnCollision;
        public Action<string> OnTrigger;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollision?.Invoke(collision.gameObject.tag);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTrigger?.Invoke(collision.gameObject.tag);
        }
    }
}
