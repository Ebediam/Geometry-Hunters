using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateBox : Box
{
    public float fireRateReduction;
    public int priceIncrease;

    public override void BoxShot()
    {
        base.BoxShot();
        if (player.goldAmount >= price)
        {
            if(player.gun.cooldownReductor <= 0f)
            {
                return;
            }
            player.gun.cooldownReductor -= fireRateReduction;
            player.UpdateGold(Enemy.deadEnemies, -price);
            price += priceIncrease;
        }


    }

}
