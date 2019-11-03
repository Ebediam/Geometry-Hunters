using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public EnemyType enemyType;
    public bool isBoss;

    public AudioSource deathSFX;

    public float remainingHitPoints;

    public int goldValue;
    public int damage;
    public ParticleSystem explosionFX;

    public Collider col;
    public Rigidbody rb;

    public Material mat;

    public float speed;
    public EnemySpawner spawner;

    public MeshRenderer meshRenderer;

    public bool isDead = false;

    public static int deadEnemies;
    public bool setToDestroy;



    // Start is called before the first frame update


    public void InitializeEnemyStats()
    {
        spawner.waveManager.player.DeathEvent += OnGameOver;
        spawner.waveManager.player.RestartEvent += OnRestart;

        hitPoints = enemyType.health;
        goldValue = enemyType.goldValue;

        isBoss = enemyType.isBoss;
        transform.localScale *= enemyType.size;
        rb.mass *= enemyType.size;
        damage = enemyType.damage;
        speed = enemyType.speed;
        meshRenderer.material = new Material(mat);
        mat = meshRenderer.material;
        remainingHitPoints = hitPoints;
        mat.SetFloat("_healthRemaining", remainingHitPoints / hitPoints);
        mat.SetColor("_initialColor", enemyType.initialColor);
        mat.SetColor("_endColor", enemyType.endColor);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (remainingHitPoints <= 0)
        {
            return;
        }


        
        if (collision.collider.gameObject.GetComponentInChildren<Bullet>())
        {
            Bullet bullet = collision.collider.gameObject.GetComponentInChildren<Bullet>();
            remainingHitPoints -= bullet.damage;

            if (!isBoss)
            {
                if (bullet.bulletEffects.Count > 0)
                {
                    foreach (BulletEffect effect in bullet.bulletEffects)
                    {
                        effect.OnActivation(this);
                    }
                }
            }
            


            mat.SetFloat("_healthRemaining", (remainingHitPoints + 0f) / hitPoints);

            if (remainingHitPoints <= 0)
            {
                Die();
            }

        }
    }

    public void OnGameOver()
    {
        Debug.Log("OnGameOver in enemy");
        spawner.waveManager.player.DeathEvent -= OnGameOver;
        speed = 0f;        
    }
    
    public void OnRestart()
    {
        spawner.waveManager.player.RestartEvent -= OnRestart;
        setToDestroy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        transform.position += transform.forward * speed * Time.deltaTime;

        if (setToDestroy)
        {
            Destroy(gameObject);
        }
    }


    public void Die()
    {

        if (isDead)
        {
            return;
        }

        spawner.waveManager.player.DeathEvent -= OnGameOver;
        spawner.waveManager.player.RestartEvent -= OnRestart;


        deathSFX.Play();
        Instantiate(explosionFX, transform.position, transform.rotation).Play();

        rb.useGravity = true;
        rb.isKinematic = false;
        gameObject.layer = 10;
        isDead = true;
        deadEnemies++;

        spawner.EnemyDeath(deadEnemies, goldValue);
        Destroy(gameObject, 0.25f);
        
    }


}
    