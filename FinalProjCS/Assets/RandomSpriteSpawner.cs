using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] RandomSprite;
    public Transform spawnPoint;
    public float spawnDelay = 3f;

    void Start()
    {
        //spawnPoint.position = new Vector3(10f, 0f, 0f); 
        Invoke("SpawnRandomEnemy", spawnDelay);   
    }

    void SpawnRandomEnemy(){
        if(RandomSprite.Length > 0 && spawnPoint != null){
            int randomIdx = Random.Range(0, RandomSprite.Length);
            GameObject randSprite = Instantiate(RandomSprite[randomIdx]);
        }
        else{
            Debug.Log("ERROR");
        }
    }

    
}
