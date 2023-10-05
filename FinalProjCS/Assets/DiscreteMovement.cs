using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveTransform(Vector3 vel){
        transform.position += vel * Time.deltaTime;
    }
}
