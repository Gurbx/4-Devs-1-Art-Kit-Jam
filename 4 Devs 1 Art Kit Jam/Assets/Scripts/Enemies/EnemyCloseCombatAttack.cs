using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombatAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private GameObject attack;

    private float timer = 2f;
    private const float attackDuration = 0.25f;

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
            timer = attackCooldown + Random.Range(-attackCooldown * 0.2f, attackCooldown * 0.2f);
            attack.SetActive(true);
            Invoke("StopAttack", attackDuration);
        }
    }

    void StopAttack()
    {
        attack.SetActive(false);
    }
}
