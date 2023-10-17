using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float mov_Speed = 5f;
    public float shoot_interval = 0.05f;
    public GameObject projectilePrefab;
    public Transform point;
    public float change_direction = 3f;
    public float Projectile_Speed = 4f;
    private float time_since_shot = 0f;

    void Start(){
        StartCoroutine(ChangeDirection());
    }

    void Update(){
        Move();
        Shoot();
    }
    void Move(){
        if (Time.frameCount % 60 == 0){
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            GetComponent<Rigidbody2D>().velocity = randomDirection * mov_Speed;
        }
    }
    void Shoot(){
        time_since_shot += Time.deltaTime;

        if(time_since_shot >= shoot_interval){
            Vector2 randomPoint = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 1f, transform.position.y + 1f));
            GameObject newProjectile = Instantiate(projectilePrefab, randomPoint, Quaternion.identity);
            Rigidbody2D projectile = newProjectile.GetComponent<Rigidbody2D>();

            if(projectile != null){
                projectile.velocity = Vector2.up * Projectile_Speed;
            }
            time_since_shot = 0f;
        }
    }
    IEnumerator ChangeDirection(){
        while(true){
            yield return new WaitForSeconds(change_direction);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
        }
    }
    
    
}
