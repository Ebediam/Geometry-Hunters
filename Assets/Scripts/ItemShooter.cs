using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    public float bulletSpeed;
    public float fireRate;
    public float shotDelay;
    

    GameObject bullet;

    bool isFiring = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            if (Input.GetMouseButtonUp(0))
            {
                CancelInvoke("Shoot");
                isFiring = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                InvokeRepeating("Shoot", shotDelay, fireRate);
                isFiring = true;
            }
        }      


    }

    void Shoot()
    {
        bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed, ForceMode.Impulse);
    }

    
}
