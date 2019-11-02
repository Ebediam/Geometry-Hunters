using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBlock : MonoBehaviour
{
    public WaveManager waveManager;
    public BlockSettings myBlock;
    public Player player;

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
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
