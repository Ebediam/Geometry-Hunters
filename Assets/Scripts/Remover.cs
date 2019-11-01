using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public delegate void EnemyThroughDelegate();
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
            if (!other.gameObject.GetComponent<Enemy>().isDead)
            {
                other.gameObject.GetComponent<Enemy>().spawner.spawnAllowed = true;
                EnemyThroughEvent();

            }
        }

        Destroy(other.gameObject);
    }
}
