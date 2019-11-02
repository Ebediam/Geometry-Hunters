using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="BulletType", fileName = "New BulletType")]
public class BulletType : ScriptableObject
{
    public string bulletID;
    public int damage;
    public Color color;
    public Color trailColor;
    public float cooldown;

    public List<BulletEffect> bulletEffects;

    public float speed;
    public float shotDelay;

    public AudioClip shotSFX;



      
}
