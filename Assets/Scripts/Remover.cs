using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public delegate void EnemyThroughDelegate(int damage);
    public EnemyThroughDelegate EnemyThroughEvent;

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
        if (other.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (!enemy.isDead)
            {
                enemy.spawner.spawnAllowed = true;
                EnemyThroughEvent(enemy.damage);

            }
        }

        Destroy(other.gameObject);
    }
}
