using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{

    public Player player;   

    // Start is called before the first frame update
    void Start()
    {
        player.DamageEvent += UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealth(int maxHealth, int health)
    {
        transform.localScale = new Vector3(((health + 0f) / maxHealth), 1, 1);

    }
}
