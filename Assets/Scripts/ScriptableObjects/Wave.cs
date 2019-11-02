using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave", fileName = "New Wave")]
public class Wave : ScriptableObject
{
    public string waveID;
    public int numberOfSpawners;
    public List<SpawnerType> enemySpawnersTypes;  


}
