using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public SpawnerType spawnerType;

    public WaveManager waveManager;

    public delegate void EnemyDeathDelegate(int deathCount, int goldAmount);
    public EnemyDeathDelegate EnemyDeathEvent;

    public delegate void EnemyLimitDelegate();
    public EnemyLimitDelegate EnemyLimitEvent;

    public StartBox startBlock;

    public int spawnNumber;
    int spawnedEnemiesCounter = 0;
    int remainingEnemies;

    public EnemyType nextEnemyType;
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
        spawnedEnemiesCounter = 0;
        spawnNumber = spawnerType.spawnNumber;
        remainingEnemies = spawnNumber;
    }

    public void SetActive()
    {
        active = true;
        spawnAllowed = true;
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

    public void SpawnTimer()
    {
        spawnAllowed = true;
    }

    public void SpawnEnemy()
    {
        CancelInvoke("SpawnTimer");
        
        spawnedEnemiesCounter++;
        nextEnemyType = ChooseEnemy();

        enemy = Instantiate(enemyPrefab, transform.position, transform.rotation).GetComponent<Enemy>();
        enemy.spawner = this;
        enemy.enemyType = nextEnemyType;
        enemy.InitializeEnemyStats();
        
        enemy.rb.velocity = Vector3.forward * enemy.speed;

        Invoke("SpawnTimer", spawnerType.delayBetweenEnemies+Random.Range(-spawnerType.delayRange, spawnerType.delayRange));
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
        CancelInvoke("SpawnTimer");
    }

    public EnemyType ChooseEnemy()
    {
        EnemyType enemyType = null;
        float randomNumber = Random.Range(0f, 1f);


        for(int i=0; i<spawnerType.availableEnemies.Count; i++)
        {
            randomNumber -= spawnerType.enemyChance[i];
            if(randomNumber <= 0)
            {
                enemyType = spawnerType.availableEnemies[i];
                break;
            }
        }


        return enemyType;
    }

    public void EnemyDeath(int deathCount, int goldAmount)
    {
        EnemyDeathEvent(deathCount, goldAmount);
        DespawnedEnemy();

    }

    public void DespawnedEnemy()
    {
        remainingEnemies--;

        if (remainingEnemies <= 0)
        {
            EnemyLimitEvent();
        }
    }
}
