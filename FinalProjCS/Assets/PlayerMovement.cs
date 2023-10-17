using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] DiscreteMovement movement;
    projectileThrower projectileThrower;
    public AudioClip launchSound;
    void Awake()
    {
        movement = GetComponent<DiscreteMovement>();
        projectileThrower = GetComponent<projectileThrower>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            vel.y = 5;
        }
        if(Input.GetKey(KeyCode.S)){
            vel.y = -5;
        }
        if(Input.GetKey(KeyCode.A)){
            vel.x = -5;
        }
        if(Input.GetKey(KeyCode.D)){
            vel.x = 5;
        }

        movement.MoveTransform(vel);
        

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            PlayLaunchSound();
        }
    }
    void PlayLaunchSound(){
        AudioSource.PlayClipAtPoint(launchSound, transform.position, 0.05f);
    }
}
