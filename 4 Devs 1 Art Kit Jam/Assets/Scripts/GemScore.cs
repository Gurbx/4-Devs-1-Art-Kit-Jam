using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemScore : MonoBehaviour
{
    [SerializeField] Text label;

    // Start is called before the first frame update
    void Start()
    {
        label.text = PlayerData.GetGems() + " / 4";
    }

}
