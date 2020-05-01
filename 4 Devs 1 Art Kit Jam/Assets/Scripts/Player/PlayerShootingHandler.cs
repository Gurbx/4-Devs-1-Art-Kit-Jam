using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingHandler : MonoBehaviour
{

    [SerializeField] private float shootSpeed = 2;
    [SerializeField] private GameObject fireballPrefab;

    [SerializeField] private CharacterController2D charController;

    private const float spawnOffset = 1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot1"))
        {
            var fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
          //  Destroy(fireball, 3f);

            Rigidbody2D rigidbody = fireball.GetComponent<Rigidbody2D>();

            if (charController.isFacingRight())
            {
                fireball.transform.position += new Vector3(spawnOffset, 0, 0);
                rigidbody.AddForce(new Vector3(shootSpeed, 300, 0));
            }
            else
            {
                fireball.transform.position += new Vector3(-spawnOffset, 0, 0);
                rigidbody.AddForce(new Vector3(-shootSpeed, 350, 0));
            }

        }
    }
}
