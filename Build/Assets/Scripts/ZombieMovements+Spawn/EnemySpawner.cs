using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject enemyPrefab; // the enemy prefab to spawn
    public float spawnDelay = 2f; // delay between spawns
    public float spawnRadius = 10f; // radius around spawner to spawn enemies
    public int maxEnemies = 10; // maximum number of enemies to spawn

    private int numEnemies = 0; // current number of enemies spawned

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (numEnemies < maxEnemies)
            {
                // spawn a new enemy
               Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnRadius, spawnRadius), 18.2f, transform.position.z + Random.Range(-spawnRadius, spawnRadius));
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

                numEnemies++;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}