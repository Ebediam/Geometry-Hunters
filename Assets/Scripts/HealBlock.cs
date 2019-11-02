using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealBlock : MonoBehaviour
{
    public WaveManager waveManager;
    public BlockSettings myBlock;
    public Player player;


    public TextMeshPro goldText; 

    public float delayToReactivate;

    // Start is called before the first frame update
    public void Start()
    {
        waveManager.WaveStartEvent += DeactivateBox;
        waveManager.WaveEndEvent += ReactivateBox;
        myBlock.OnCollisionEvent += HealPlayer;

        DeactivateBox();

    }

    public void DeactivateBox()
    {
        gameObject.SetActive(false);
    }
    public void HealPlayer()
    {
        if(player.goldAmount >= (player.maxHealth- player.health))
        {
            player.UpdateGold(Enemy.deadEnemies, (player.health - player.maxHealth));
            player.TakeDamage(player.health - player.maxHealth);
        }
               
        DeactivateBox();
    }
    public void ReactivateBox()
    {
        Invoke("DelayedReactivateBox", delayToReactivate);
    }

    public void DelayedReactivateBox()
    {
        int missingHealth = player.maxHealth - player.health;
        if (missingHealth == 0)
        {
            return;
        }
        gameObject.SetActive(true);

        goldText.text = missingHealth.ToString() + " gold";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
