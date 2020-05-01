using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    const int startHealth = 5;

    private static int health;
    private static int gems;

    void Awake()
    {
        health = startHealth;
        gems = 0;

        DontDestroyOnLoad(this.gameObject);
    }

    public static void SaveData(int h, int g)
    {
        health = h;
        gems = g;
    }

    public static void SaveHealth(int h)
    {
        health = h;
    }

    public static int GetGems()
    {
        return gems;
    }

    public static int GetHealth()
    {
        return health;
    }
}
