using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float aggroRange;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private bool canJump;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpChance;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Animator animator;


    private bool facingRight;
    private float jumpTimer;

    private bool isGrounded = true;

    private GameObject player;
    private Rigidbody2D rigidbody2D;
    private Vector3 heading;

    public UnityEvent OnLandEvent;

    const float minRange = 1f; //Dont get too close to the player (to avoid overlap)

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();

        maxVelocity += Random.Range(-0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = Vector3.Distance(player.gameObject.transform.position, transform.position);

        if (distFromPlayer <= aggroRange)
        {
            heading = player.transform.position - transform.position;

            if (distFromPlayer <= minRange)
            {
                heading = heading * -1;
            }
        }
        else
            heading = Vector3.zero;


        if (rigidbody2D.velocity.x < 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (rigidbody2D.velocity.x > 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //Jump
        if (canJump)
        {
            bool wasGrounded = isGrounded;
            isGrounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }


            if (isGrounded && heading.y > 1 && jumpTimer <= 0 && Mathf.Abs(heading.x) < aggroRange/2) 
            {
                if (Random.Range(0,1f) < jumpChance) rigidbody2D.AddForce(new Vector3(0, jumpForce, 0));
                jumpTimer = jumpCooldown + Random.Range(-0.25f, 0.75f);
            }

            jumpTimer -= Time.deltaTime;
        }

        // Horizontal Movement
        //if (jumpTimer-jumpTimer*0.5f > 0) return; // DONT MOVE WHEN JUMPING

        if (isGrounded)
        {
            if (heading.x > 1 && rigidbody2D.velocity.x < maxVelocity)
            {
                rigidbody2D.AddForce(new Vector3(movementSpeed, 0, 0));
            }
            else if (heading.x < -1 && rigidbody2D.velocity.x > -maxVelocity)
            {
                rigidbody2D.AddForce(new Vector3(-movementSpeed, 0, 0));
            }
        }

        animator.SetFloat("velocity", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetBool("grounded", isGrounded);
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
