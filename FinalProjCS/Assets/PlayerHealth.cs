using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    private float currHealth;

    public Slider healthSlider;
    void Start()
    {
        currHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("DamageObject")){
            TakeDamage(10f);
        }
        else if(collision.gameObject.CompareTag("HealthObject")){
            Heal(10f);
            
        }

    }
    void TakeDamage(float DamageAmount){
        currHealth -= DamageAmount;
        currHealth = Mathf.Clamp(currHealth, 0f, maxHealth);
        UpdateHealthUI();
    }
    void Heal(float HealAmount){
        currHealth += HealAmount;
        currHealth = Mathf.Clamp(currHealth, 0f, maxHealth);
        UpdateHealthUI();
    }
    void UpdateHealthUI(){
        healthSlider.value = currHealth / maxHealth;
    }
}
