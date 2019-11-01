using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void EnemyDeathDelegate(int deathCount, int goldAmount);
    public EnemyDeathDelegate EnemyDeathEvent;

    public Start startBlock;

    public EnemyType enemySpawned;

    public int spawnNumber;
    int spawnedEnemiesCounter = 0;

    public GameObject enemyPrefab;
    public Enemy enemy;
    public bool spawnAllowed = true;
    public float xRange;
    public float yRange;
    public float delayBeforeStart;

    float xOffset;
    float yOffset;

    public bool active = false;

    void Start()
    {
        startBlock.StartEvent += Activate;
        
    }

    public void Activate()
    {
        Invoke("SetActive", delayBeforeStart);
    }

    public void SetActive()
    {
        active = true;
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
        spawnedEnemiesCounter++;
        enemy = Instantiate(enemyPrefab, transform.position, transform.rotation).GetComponent<Enemy>();
        enemy.spawner = this;
        enemy.enemyType = enemySpawned;
        enemy.InitializeEnemyStats();
        
        enemy.rb.velocity = Vector3.forward * enemy.speed;
        if(spawnedEnemiesCounter >= spawnNumber)
        {
            StopSpawner();
        }
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

    public void StopSpawner()
    {
        active = false;
        spawnAllowed = true;
    }
}
