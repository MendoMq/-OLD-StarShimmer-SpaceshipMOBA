using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public GameObject deathEffectPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth)health=maxHealth;

        if(health <= 0){
            if(deathEffectPrefab != null){
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public int GetHealth(){
        return health;
    }

    public void SetHealth(int newHealth){
        health = newHealth;
    }

    public void ChangeHealth(int healthChange){
        health += healthChange;
    }
}
