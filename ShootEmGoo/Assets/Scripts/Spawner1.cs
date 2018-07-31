using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour {

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime = 1.0f;
    public float spawnDelay = 2.0f;
    public float spawn5Time = 1f;
    public float spawn5Delay = 0.5f;
    public int enemyCount = 5;

    public int spawnedEnemies = 0;

    void Update()
    {
        if (spawnedEnemies < enemyCount)
        {
            spawnedEnemies++;
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        } else if (spawnedEnemies >0 && spawnedEnemies <= enemyCount)
        {
            spawnedEnemies--;
        } else if (spawnedEnemies <= 0)
        {

        }
    }


    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        spawnedEnemies++;
        if (spawnedEnemies >= enemyCount)
        {
            CancelInvoke("SpawnObject");
            spawnedEnemies = 0;
        }
    }
}
