using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    bool isRolling;
    [SerializeField]
    Rigidbody2D _rigidbody;
    void Update()
    {
        PlayerMovement();
        DodgeRoll();
    }

    public void PlayerMovement()
    {
        //handles the left,right,up and down
        if (Input.GetButton("s"))
        {

            transform.Translate(0, -.01f, 0);


        }
        if (Input.GetButton("w"))
        {
            transform.Translate(0, .01f, 0);
        }
        if (Input.GetButton("a"))
        {
            transform.Translate(-.01f, 0, 0);
        }
        if (Input.GetButton("d"))
        {
            transform.Translate(.01f, 0, 0);
        }

        
    }

    private void DodgeRoll()
    {
        if (isRolling == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
            }
        }

    }
}
