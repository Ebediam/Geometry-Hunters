using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfuseRayBox : Box
{
    public bool unlocked = false;

    public override void BoxShot()
    {
        base.BoxShot();

        if (player.goldAmount >= price)
        {

            unlocked = true;
            player.UpdateGold(Enemy.deadEnemies, -price);
            player.gun.UpdateSecundaryBullet(player.gun.bulletTypes[2], 2);

            price = 0;

        }

    }

    public override void DelayedReactivateBox()
    {

        base.DelayedReactivateBox();
        /*if (unlocked)
        {
            gameObject.SetActive(false);
        }*/
        if (player.isDead)
        {
            unlocked = false;
            price = 25;

        }
    }
}
