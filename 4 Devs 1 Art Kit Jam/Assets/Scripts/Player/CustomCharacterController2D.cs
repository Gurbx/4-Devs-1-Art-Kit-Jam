using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomCharacterController2D : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 400f;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask m_WhatIsGround;

    public UnityEvent OnLandEvent;

    const float k_GroundedRadius = 0.2f;
    private Rigidbody2D rigidbody2D;
    private bool isGrounded;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckTransform.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }


    }
}
