using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner Settings", fileName = "New Spawner")]
public class SpawnerType : ScriptableObject
{
    public string spawnerID;
    public List<EnemyType> availableEnemies;
    [Range(0,1)]
    public List<float> enemyChance;
    public int spawnNumber;
    public float delayBetweenEnemies;
    public float delayRange;


}
