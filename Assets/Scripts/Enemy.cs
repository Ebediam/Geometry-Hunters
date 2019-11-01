using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public EnemyType enemyType;

    public int remainingHitPoints;

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

    

    // Start is called before the first frame update



    public void InitializeEnemyStats()
    {
        hitPoints = enemyType.health;
        goldValue = enemyType.goldValue;
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
            remainingHitPoints -= collision.collider.gameObject.GetComponentInChildren<Bullet>().damage;
            mat.SetFloat("_healthRemaining", (remainingHitPoints + 0f) / hitPoints);

            if (remainingHitPoints <= 0)
            {
                Die();
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        transform.position += transform.forward * speed * Time.deltaTime;


    }


    public void Die()
    {
        if (isDead)
        {
            return;
        }

        Instantiate(explosionFX, transform.position, transform.rotation).Play();
        rb.useGravity = true;
        rb.isKinematic = false;
        spawner.enemy = null;
        spawner.spawnAllowed = true;
        gameObject.layer = 10;
        isDead = true;
        deadEnemies++;

        spawner.EnemyDeathEvent(deadEnemies, goldValue);
        Destroy(gameObject);
        
    }


}
    