using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
     
     float horizontalMove = 0f;
     bool jump = false;

     public float runSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove =  Input.GetAxisRaw("Horizontal")* runSpeed;
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping",true);
        }
    }
    public void OnLanding ()
    {
        animator.SetBool("IsJumping",false);
    }
    void FixedUpdate() {
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);
        jump = false;    
    }
}
