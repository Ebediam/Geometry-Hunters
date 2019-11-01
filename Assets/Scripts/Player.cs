using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void DamageDelegate(int maxHealth, int health);
    public DamageDelegate DamageEvent;

    public delegate void GoldDelegate(int addedGold, int totalGold);
    public GoldDelegate GoldUpdateEvent;
    

    public int goldAmount = 0;

    

    public int maxHealth;
    public int health;

    public List<Remover> removers;
    public List<EnemySpawner> enemySpawners;

    void Start()
    {
        health = maxHealth;
        foreach (Remover remover in removers)
        {
            remover.EnemyThroughEvent += TakeDamage;
        }

        foreach(EnemySpawner spawner in enemySpawners)
        {
            spawner.EnemyDeathEvent += UpdateGold;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGold(int deathCount, int gold)
    {
        Debug.Log("Update gold");
        goldAmount += gold;
        GoldUpdateEvent(gold, goldAmount);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamageEvent(maxHealth, health);
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
    }
}
