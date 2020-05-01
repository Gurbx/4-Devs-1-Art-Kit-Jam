using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUI : MonoBehaviour
{
    [SerializeField] private Text label;

    private int gems;
    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gems = PlayerData.GetGems();
        label.text = gems + " / 4";
    }

    void Update()
    {
        if (pHealth.gems != gems)
        {
            gems = pHealth.gems;
            label.text = gems + " / 4";
        }
    }
}
