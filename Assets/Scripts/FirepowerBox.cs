using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepowerBox : Box
{
    public float damageAddition;

    public override void BoxShot()
    {
        if (player.goldAmount >= price)
        {
            player.gun.bulletDamageMultiplier += damageAddition;
            player.UpdateGold(Enemy.deadEnemies, -price);
            price += 50;
            player.gun.UpdateGunColor();            
        }

        base.BoxShot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
