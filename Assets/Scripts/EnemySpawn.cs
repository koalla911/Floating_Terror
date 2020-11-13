using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float randX;
    private float randY;
    Vector2 startSpawnPoint;
    public float spawnRate = 2f;
    private float nextSpawnPoint = 0.0f;

    private void Update()
    {
        if (Time.time > nextSpawnPoint)
        {
            nextSpawnPoint = Time.time + spawnRate;
            randX = Random.Range(-30f, 30f);
            randY = Random.Range(-30f, 30f);
            startSpawnPoint = new Vector2 (randX, randY);
            Instantiate(enemy, startSpawnPoint, Quaternion.identity);
        }
    }

}
