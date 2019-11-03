using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    public BulletType defaultBullet;

    public BulletType mainBullet;
    
    public BulletType secondaryBullet;

    public AudioSource shotSFX;
    public AudioSource secondaryShotSFX;

    public MeshRenderer mesh;

    public float maxDamageMultiplier = 5f;

    public float bulletSpeed;

    public float cooldownReductor = 1f;
    public float bulletDamageMultiplier = 1f;

    public Player player;

    Bullet bullet;

    bool isFiring = false;
    bool isSecondaryFiring = false;

    public bool secondaryShooting = false;

    public Material gunTipMaterial;

    public List<BulletType> bulletTypes;

    public int currentSecondaryPower;

    // Start is called before the first frame update
    void Start()
    {
        shotSFX.clip = mainBullet.shotSFX;
        gunTipMaterial.SetFloat("_isCharged", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Invoke("MainCooldown", mainBullet.cooldown*cooldownReductor);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!player.isDead)
                {
                    Shoot(mainBullet, true);
                    isFiring = true;
                }
                else
                {
                    player.RestartGame();
                }



            }
        }

        if (!secondaryShooting)
        {
            return;
        }

        if (isSecondaryFiring)
        {
            if (Input.GetMouseButtonUp(1))
            {

                Invoke("SecondaryCooldown", secondaryBullet.cooldown*cooldownReductor);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!player.isDead)
                {
                    Shoot(secondaryBullet, false);
                    gunTipMaterial.SetFloat("_isCharged", 0f);
                    isSecondaryFiring = true;
                }
            }
        }


    }


    public void MainCooldown()
    {
        CancelInvoke("MainCooldown");
        isFiring = false;
    }

    public void SecondaryCooldown()
    {
        CancelInvoke("SecondaryCooldown");
        isSecondaryFiring = false;
        gunTipMaterial.SetFloat("_isCharged", 1f);
    }

    void Shoot(BulletType bulletType, bool main)
    {
        bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).GetComponent<Bullet>();
        bullet.bulletType = bulletType;
        
        bullet.rb.AddForce(bullet.transform.forward*bulletSpeed, ForceMode.Impulse);
        bullet.damageMultiplier = bulletDamageMultiplier;

        if (main)
        {
            shotSFX.Play();
        }
        else
        {
            secondaryShotSFX.Play();
            bullet.bulletEffects[currentSecondaryPower-1].isActive = true;
        }

    }


    public void UpdateGunColor()
    {
        mesh.material.SetFloat("_PowerLevel", bulletDamageMultiplier / maxDamageMultiplier);
    }
      
    public void ResetGun()
    {
        bulletDamageMultiplier = 1f;
        UpdateGunColor();
        cooldownReductor = 1f;
        mainBullet = defaultBullet;
        secondaryBullet = null;
        secondaryShooting = false;
        gunTipMaterial.SetFloat("_isCharged", 0f);
    }

    public void UpdateSecundaryBullet(BulletType bulletType, int effectNumber)
    {
        secondaryBullet = bulletType;
        secondaryShooting = true;
        secondaryShotSFX.clip = secondaryBullet.shotSFX;
        gunTipMaterial.SetFloat("_isCharged", 1f);
        currentSecondaryPower = effectNumber;
        
    }
    
}
