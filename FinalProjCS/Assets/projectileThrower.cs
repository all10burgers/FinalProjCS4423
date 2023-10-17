using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    public void Throw(){
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
