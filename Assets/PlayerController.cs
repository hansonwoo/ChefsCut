using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed;
    [SerializeField]
    float dodgeSpeed; 
    private State state;
    Vector3 dodgeDir;
    [SerializeField]
    Rigidbody2D rigidbody;
   private enum State
    {
        Normal, 
        DodgeRoll,
    }
    private void Awake()
    {
        state = State.Normal;
    }
    void Update()
    {
        switch (state)
        {
            case State.Normal:
                HandleMovement();
                HandleDodgeState();
                break;
            case State.DodgeRoll:
                HandleDodgeRoll();
                break;
        }
        
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rigidbody.velocity = movement * speed;
        //if (Input.GetButton("down"))
        //{
        //  transform.Translate(0, -speed, 0);

        //}
        //if (Input.GetButton("up"))
        //{
        //    transform.Translate(0, speed, 0);

        //}
        //if (Input.GetButton("left"))
        //{
        //    transform.Translate(-speed, 0, 0);

        //}
        //if (Input.GetButton("right"))
        //{
        //    transform.Translate(speed, 0, 0);

        //} 


    } 

    private void HandleDodgeState()
    {
        if (Input.GetButton("dodge"))
        {
            state = State.DodgeRoll;
           
            state = State.Normal;
        }
    }
    private void HandleDodgeRoll()
    {
        
    }
    
}
