using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{

    public bool isActive;
    public virtual void OnActivation(Enemy enemy)
    {
        if (!isActive)
        {
            return;
        }
    }


}
