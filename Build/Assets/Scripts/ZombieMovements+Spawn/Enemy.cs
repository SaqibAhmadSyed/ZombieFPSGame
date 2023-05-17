using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public bool hitcounter = false;
    void Start()
    {
        currentHealth = maxHealth;
        hitcounter = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            transform.GetComponent<Animation>().Play("Death");
            Die();
            if (hitcounter == false)
            {
                PlayerHealth.zombiecounter = PlayerHealth.zombiecounter + 1;
                hitcounter = true;
            }
        }
    }

    void Die()
    {
        // add code to handle the enemy's death
        Destroy(gameObject);


    }
}
