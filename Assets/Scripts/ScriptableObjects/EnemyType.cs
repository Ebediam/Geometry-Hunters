using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New enemy", menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public string enemyName;
    public float size;
    public int health;
    public int damage;
    public int goldValue;
    public float speed;
    public bool isBoss;

    public Color initialColor;
    public Color endColor;
}
