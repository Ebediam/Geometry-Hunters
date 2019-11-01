using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCountUpdater : MonoBehaviour
{
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI goldText;

    public List<EnemySpawner> enemySpawners;


    // Start is called before the first frame update
    void Start()
    {
        foreach(EnemySpawner spawner in enemySpawners)
        {
            spawner.EnemyDeathEvent += UpdateDeathText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDeathText(int deathCount, int goldAmount)
    {
        deathText.text = "Kills: " + deathCount.ToString();
    }
}
