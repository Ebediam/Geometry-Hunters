using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void DamageDelegate(int maxHealth, int health);
    public DamageDelegate DamageEvent;

    public int maxHealth;
    public int health;

    public List<Remover> removers;

    void Start()
    {
        health = maxHealth;
        foreach (Remover remover in removers)
        {
            remover.EnemyThroughEvent += TakeDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health -= 1;
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
