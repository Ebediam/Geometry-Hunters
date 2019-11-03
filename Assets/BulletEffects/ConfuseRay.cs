using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfuseRay : BulletEffect
{
    public override void OnActivation(Enemy enemy)
    {
        if (isActive)
        {
            base.OnActivation(enemy);
            enemy.speed *= -1f;
        }

    }
}
