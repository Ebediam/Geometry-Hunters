using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : BulletEffect
{
    public override void OnActivation(Enemy enemy)
    {
        base.OnActivation(enemy);
        enemy.speed = 0f;
        
    }

}
