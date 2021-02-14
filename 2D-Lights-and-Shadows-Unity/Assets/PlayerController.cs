using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float x;
        [SerializeField] private bool isGrounded;
        public float movementSpeed;
        public float jumpVelocity;
        

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            x = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(x * movementSpeed, body.velocity.y);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                body.velocity = body.velocity + Vector2.up * jumpVelocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("ground"))
            {
                isGrounded = false;
            }
        }
    }
}