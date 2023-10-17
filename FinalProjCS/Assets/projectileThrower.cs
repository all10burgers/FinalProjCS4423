using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileThrower : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    public void Throw(Vector3 targetPosition){
        Rigidbody2D newProj = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        newProj.velocity = (targetPosition - transform.position).normalized * speed;
    }
}
