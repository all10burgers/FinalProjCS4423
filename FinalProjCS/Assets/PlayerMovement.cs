using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    DiscreteMovement movement;
    void Awake()
    {
        movement = GetComponent<DiscreteMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }
        else if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }
        else if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }
        else if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }

        movement.MoveTransform(vel);
    }
}
