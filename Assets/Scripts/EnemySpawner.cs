using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public Enemy enemy;
    public bool spawnAllowed = true;
    public float xRange;
    public float yRange;

    float xOffset;
    float yOffset;

    public bool active = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }


        if (!spawnAllowed)
        {
            return;
        }


        ResetSpawner();
        MoveSpawner();
        SpawnEnemy();
        spawnAllowed = false;


    }

    public void SpawnEnemy()
    {
        enemy = Instantiate(enemyPrefab, transform.position, transform.rotation).GetComponent<Enemy>();
        enemy.spawner = this;
        enemy.rb.velocity = Vector3.forward * enemy.speed;
    }

    public void MoveSpawner()
    {
        xOffset = Random.Range(-xRange, xRange);
        yOffset = Random.Range(-yRange, yRange);

        transform.position += (transform.right * xOffset + transform.up * yOffset);
    }

    public void ResetSpawner()
    {
        transform.position -= (transform.right * xOffset + transform.up * yOffset);
    }
}
