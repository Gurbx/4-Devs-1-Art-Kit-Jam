using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public bool isHealth;

    [SerializeField] private GameObject pickupEffectPrefab;
    [SerializeField] private GameObject setActiveOnPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var deathEffect = Instantiate(pickupEffectPrefab, transform.position, transform.rotation);
            deathEffect.transform.parent = null;

            if (isHealth) collision.GetComponent<PlayerHealth>().health++;
            else
            {
                collision.GetComponent<PlayerHealth>().gems++;
                if (setActiveOnPickup != null) setActiveOnPickup.SetActive(true);
            }

            Destroy(deathEffect, 6f);

            Destroy(gameObject);
        }
    }
}
