using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float runSpeed = 40f;
    public Rigidbody2D rigidBody2D;
    public float timeHeld;

    float horizontalMove = 0f;
    bool jump = false;
    

    void Start()
    {
        
    }

    private void Update()
    {
        
        horizontalMove = runSpeed;
        // Probably unneeded, but might make the game feel a little more responsive, so might be worth adding back even if it has a performance hit.
        //if (Input.GetButtonDown("Jump"))
        //{
        //    timeHeld += Time.deltaTime;
        //} 
        
        if (Input.GetButton("Jump"))
        {
            timeHeld += Time.deltaTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            controller.Jump();
            timeHeld = 0;
            jump = true;
        }
        animator.SetFloat("verticalVelocity", rigidBody2D.velocity.y);
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.pressure > 0)
            {
                timeHeld += Time.deltaTime;
            }
        }
        else
        {
            controller.Jump();
            timeHeld = 0;
            jump = true;
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}

