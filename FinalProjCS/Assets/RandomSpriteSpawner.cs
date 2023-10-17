using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RandomSprite;
    public Transform spawnPoint;
    public float spawnDelay = 3f;

    void Start()
    {
        //spawnPoint.position = new Vector3(10f, 0f, 0f); 
        SpawnRandomEnemy();   
    }

    void SpawnRandomEnemy(){
        StartCoroutine(SpawnRandomEnemyRoutine());

        IEnumerator SpawnRandomEnemyRoutine(){
            while(true){
                yield return new WaitForSeconds(3);
                GameObject randSprite = Instantiate(RandomSprite, new Vector3(Random.Range(-40,10), Random.Range(-3,12),0), Quaternion.identity);
                //Destroy(randSprite,10);
            }

            yield return null;
        }
    }

    
}
