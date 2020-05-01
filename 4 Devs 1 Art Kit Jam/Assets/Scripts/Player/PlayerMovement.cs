using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D charController;

    [SerializeField] private float runSpeed = 40f;

    private bool jump = false;
    private float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButton("Jump")) jump = true;
        
    }

    private void FixedUpdate()
    {
        charController.Move(horizontalMove, false, jump);
        jump = false;
    }

}
