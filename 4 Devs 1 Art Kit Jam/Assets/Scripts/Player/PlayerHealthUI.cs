using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthIconPrefab;

    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth.health > transform.childCount)
        {
            var healthIcon = Instantiate(healthIconPrefab, transform.position, transform.rotation);
            healthIcon.transform.parent = transform;
        }
        else if (pHealth.health < transform.childCount)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        
    }
}
