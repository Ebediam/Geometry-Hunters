using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeamBox : Box
{
    public bool iceBeamUnlocked = false;

    public override void BoxShot()
    {        
        base.BoxShot();

        if (player.goldAmount >= price)
        {

            iceBeamUnlocked = true;
            player.UpdateGold(Enemy.deadEnemies, -price);
            player.gun.UpdateSecundaryBullet(player.gun.bulletTypes[1], 1);
            price = 0;
            
            

        }

    }

    public override void DelayedReactivateBox()
    {

        base.DelayedReactivateBox();
        /*if (iceBeamUnlocked)
        {
            gameObject.SetActive(false);
        }*/
        if (player.isDead)
        {
            iceBeamUnlocked = false;
            price = 25;
        }
    }

}
