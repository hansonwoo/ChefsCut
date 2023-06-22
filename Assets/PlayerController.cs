using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

   
    void Update()
    {
        if (Input.GetButton("s")) 
        {

            transform.Translate(0, -.01f, 0);


        }


        if (Input.GetButton("w"))
        {
            transform.Translate(0,.01f,0);
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
}
