using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public delegate void EnemyThroughDelegate(int damage);
    public EnemyThroughDelegate EnemyThroughEvent;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (player.isDead)
        {
            return;
        }
     

        if (other.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.spawner.spawnAllowed = true;
            EnemyThroughEvent(enemy.damage);

            enemy.spawner.DespawnedEnemy();            
            enemy = null;
        }


       Destroy(other.gameObject);


    }
}
