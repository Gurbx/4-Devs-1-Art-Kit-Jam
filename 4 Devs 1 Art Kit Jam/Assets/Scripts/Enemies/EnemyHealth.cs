using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private float hitForce;

    [SerializeField] private GameObject deathExplossionPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            collision.gameObject.GetComponent<Fireball>().DestroyFireball();

            health--;


            if (health <= 0)
            {
                var deathEffect = Instantiate(deathExplossionPrefab, transform.position, transform.rotation);
                deathEffect.transform.parent = null;

                Destroy(deathEffect, 6f);
                Destroy(gameObject);
                ScreenshakeHandler.AddScreenShake(10, 10, 0.2f);
            }
            else
            {
                ScreenshakeHandler.AddScreenShake(5, 5, 0.1f);
                animator.SetTrigger("hit");
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, hitForce, 0));
            }
        }
    }

}
