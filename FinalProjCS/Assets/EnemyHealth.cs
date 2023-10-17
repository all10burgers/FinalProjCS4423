using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currHealth;
    public int scoreValue = 10;
    private ScoreManager scoreManager;
    

    //public Slider healthSlider;
    void Start()
    {
        currHealth = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
        //UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0){
            DestroyEnemy();
            if(scoreManager != null){
                scoreManager.IncreaseScore(scoreValue);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){

        
        if(other.CompareTag("PlayerProj")){
            
            
            TakeDamage(10f);
            Debug.Log("BREAK");
        }

    }
    void TakeDamage(float DamageAmount){
        currHealth -= DamageAmount;
        currHealth = Mathf.Clamp(currHealth, 0f, maxHealth);
        
        //UpdateHealthUI();
    }
    void DestroyEnemy(){
        if(gameObject != null){

            
            Destroy(gameObject);
        }
    }
    
    
}
