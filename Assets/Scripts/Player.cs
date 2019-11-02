using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void DamageDelegate(int maxHealth, int health);
    public DamageDelegate DamageEvent;

    public delegate void GoldDelegate(int addedGold, int totalGold);
    public GoldDelegate GoldUpdateEvent;


    public delegate void DeathDelegate();
    public DeathDelegate DeathEvent;

    public delegate void RestartDelegate();
    public RestartDelegate RestartEvent;

    public int goldAmount = 0;

    public bool isDead;
    

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
            remover.player = this;
        }

        foreach(EnemySpawner spawner in enemySpawners)
        {
            spawner.EnemyDeathEvent += UpdateGold;
        }
    }

    public void ResetPlayer()
    {
        isDead = false;
        TakeDamage(health - maxHealth);
        UpdateGold(0, -goldAmount);
    }

    public void RestartGame()
    {
        RestartEvent?.Invoke();
        ResetPlayer();
        
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
        if (isDead)
        {
            return;
        }

        health -= damage;
        DamageEvent(maxHealth, health);
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        DeathEvent?.Invoke();
    }
}
