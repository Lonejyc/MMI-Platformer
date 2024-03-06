using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 3.0f;
    public float gravity = 9.8f;
    private Vector3 moveD = Vector3.zero;

    public Transform Body;
    private Vector3 rotation;
    CharacterController controller;
    Animator anim;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        handleAnimation();
        if (controller.isGrounded)
        {
            
            moveD = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;


            
            // if (moveD.x > 0)
            //     Flip();
            // else if (moveD.x < 0)
            //     Flip();

            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpForce;
            }
        }
        moveD.y -= gravity * Time.deltaTime;
        controller.Move(moveD * Time.deltaTime);
    }

    void handleAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isWalking", true);
            // anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            // anim.SetBool("isRunning", false);
        }
        if (Input.GetButton("Jump"))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
   
}