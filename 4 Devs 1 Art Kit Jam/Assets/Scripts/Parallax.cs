using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject reference;
    [SerializeField] private float scroll;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(reference.transform.position.x * scroll, transform.position.y * 0.05f);
        transform.position = pos;
        
    }
}
