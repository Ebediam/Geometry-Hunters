using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage;
    public float damageMultiplier = 1f;
    public TrailRenderer trail;
    public MeshRenderer mesh;
    public BulletType bulletType;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        damage = bulletType.damage*damageMultiplier;
        trail.startColor = bulletType.trailColor;

        mesh.material.SetColor("_bulletColor", bulletType.color);
        trail.material.SetColor("_bulletColor", bulletType.trailColor);
                     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 0.01f);
    }
}
