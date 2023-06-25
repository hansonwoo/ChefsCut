using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
    float dodgeDist;
    [SerializeField]
    float timer;
    [SerializeField]
    int dodgeCharge = 1;
    private State state;
    Vector2 dodgeDir;
    float horizontalInput;
    float verticalInput;
    [SerializeField]
    Rigidbody2D rigidbody;


    float dodgeRecharge = 2;
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
                HandleDodgeRoll(horizontalInput,verticalInput);
                break;
        }
       if (dodgeCharge == 0)
        {
            timer = timer + Time.deltaTime;
            if (timer > dodgeRecharge)
            {
                if (dodgeCharge == 0)
                {
                    dodgeCharge++;

                }
                timer = 0;
            }
            
        }
       
    }

    private void HandleMovement()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rigidbody.velocity = movement * speed;
    } 

    private void HandleDodgeState()
    {
        dodgeDir = new Vector2(horizontalInput, verticalInput);
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("dodge begin");
            state = State.DodgeRoll;
            Debug.Log("dodge end");
            
        }
        
    }
    private void HandleDodgeRoll(float horizontalInput, float verticalInput)
    {
        dodgeDir = new Vector2(horizontalInput, verticalInput);

        if (dodgeCharge > 0)
        {
            transform.Translate(dodgeDir * dodgeDist);
            dodgeCharge--;
            state = State.Normal;
        }
        else if (dodgeCharge == 0)
        {
            state = State.Normal;

        }
    }

}
