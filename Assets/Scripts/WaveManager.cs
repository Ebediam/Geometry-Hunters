using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public delegate void WaveStartDelegate();
    public WaveStartDelegate WaveStartEvent;

    public delegate void WaveEndDelegate();
    public WaveEndDelegate WaveEndEvent;

    public delegate void GameEndDelegate();
    public GameEndDelegate GameEndEvent;

    public StartBox startBlock;

    public int wavesCompleted = 0;

    public int spawnerCounter;

    public List<Wave> waves;

    public List<EnemySpawner> spawners;

    public Player player;
    public int lastWave;


    
    // Start is called before the first frame update
    void Start()
    {
        startBlock.StartEvent += OnStartShot;
        player.RestartEvent += OnRestart;

        foreach (EnemySpawner spawner in spawners)
        {
            WaveStartEvent += spawner.Activate;
            spawner.EnemyLimitEvent += SpawnerFinish;
            spawner.waveManager = this;
            player.DeathEvent += spawner.StopSpawner;
        }
    }

    public void OnRestart()
    {
        Enemy.deadEnemies = 0;
        wavesCompleted = 0;
    }

    public void OnStartShot()
    {
        for(int i=0; i < spawners.Count; i++)
        {
            spawners[i].spawnerType = waves[wavesCompleted].enemySpawnersTypes[i]; 
            
        }

        spawnerCounter = waves[wavesCompleted].numberOfSpawners;
        WaveStartEvent();

    }

    public void SpawnerFinish()
    {
        spawnerCounter--;
        if(spawnerCounter <= 0)
        {

            wavesCompleted++;
            WaveEndEvent();

            if (wavesCompleted >= waves.Count)
            {
                EndGame();
            }
        }

    }

    public void EndGame()
    {
        GameEndEvent?.Invoke();
        wavesCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
