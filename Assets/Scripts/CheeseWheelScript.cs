using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWheelScript : MonoBehaviour
{
    /// <summary>
    /// The target the enemy will attack. Usually the player
    /// </summary>
    public GameObject Target;

    [SerializeField]
    private float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, MovementSpeed * Time.deltaTime);
    }
}
