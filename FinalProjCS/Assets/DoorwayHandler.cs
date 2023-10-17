using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayHandler : MonoBehaviour
{
   public GameObject[] roomPrefabs;

   private void Start(){
    SpawnRoom();
   }

   private void OnTriggerEnter2D(Collider2D other){

    if(other.CompareTag("Player")){
        Debug.Log("HELLO");
        //GameObject roomPrefab = GetRandomRoom();

        //Instantiate(roomPrefab, other.transform.position, Quaternion.identity);
    }
   }
   private GameObject GetRandomRoom(){
    int rand = Random.Range(0, roomPrefabs.Length);
    return roomPrefabs[rand];
   }

   private void SpawnRoom(){
    GameObject initial_room = GetRandomRoom();
    Instantiate(initial_room, Vector3.zero,Quaternion.identity);
   }
}
