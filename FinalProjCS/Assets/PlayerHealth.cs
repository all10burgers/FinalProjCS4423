using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 180;
    private float currHealth;
    

    public Slider healthSlider;
    public Text HealthText;
    void Start()
    {
        currHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("DamageObject")){
            Debug.Log("HELP");
            TakeDamage(15);
        }
        if(other.CompareTag("HealthObject")){
            Heal(15);
            
            
        }
      

    }
    void TakeDamage(float DamageAmount){
        currHealth -= DamageAmount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        
        UpdateHealthUI();

        if(currHealth <= 0){
            SceneManager.LoadScene("MainMenuScene");
        }
    }
    void Heal(float HealAmount){
        currHealth += HealAmount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        UpdateHealthUI();
    }
    void UpdateHealthUI(){
        HealthText.text = "Health: " + currHealth.ToString();
        
    }
    
}
