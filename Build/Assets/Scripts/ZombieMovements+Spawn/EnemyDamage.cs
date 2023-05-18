using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10; // amount of damage to deal to the player
    public float attackRange = 2f; // range at which the enemy can attack the player

    private Transform player; // reference to the player's transform

    private void Start()
    {
        // find the player object in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // if the player is within attack range, deal damage
        if (distanceToPlayer <= attackRange)
        {

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                transform.GetComponent<Animation>().Play("Attack1");
                playerHealth.TakeDamage(damage);

            }
        }
    }
}