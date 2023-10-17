using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 0.125f;
    void Awake(){
        //mov = GetComponent<DiscreteMovement>();
    }
    void LateUpdate(){
        if(player != null){
            Vector3 targetPos = new Vector3(player.position.x,player.position.y, player.position.z);
            //mov.MoveTransform(vel);
            Vector3 smooth = Vector3.Lerp(transform.position, targetPos, speed );
            transform.position = smooth;
        }
    }
}
