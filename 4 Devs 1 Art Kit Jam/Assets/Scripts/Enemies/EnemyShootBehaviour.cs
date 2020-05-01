using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBehaviour : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private GameObject projectilePrefab;

    private float timer = 2f;
//    private const float attackDuration = 0.25f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;


        float distFromPlayer = Vector3.Distance(player.gameObject.transform.position, transform.position);
        if (distFromPlayer <= attackRange)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            Vector2 heading = player.transform.position - transform.position;



            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(heading.x*30, Mathf.Abs(heading.x + 500f)));
            timer = attackCooldown + Random.Range(attackCooldown * 0.8f, attackCooldown * 1.2f);
        }
    }

}
