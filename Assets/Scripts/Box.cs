﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    public bool activeAtBeginning;
    public delegate void StartDelegate();

    public StartDelegate StartEvent;

    public WaveManager waveManager;

    public float delayToReactivate;

    public BlockSettings myBlock;

    public Player player;

    public TextMeshPro goldText;
    public int price;
    public int originalPrice;


    // Start is called before the first frame update
    public void Start()
    {
        originalPrice = price;
        waveManager.WaveEndEvent += ReactivateBox;
        waveManager.WaveStartEvent += DeactivateBox;
        myBlock.OnCollisionEvent += BoxShot;
        player.RestartEvent += DelayedReactivateBox;
        gameObject.SetActive(activeAtBeginning);
    }


    public void DeactivateBox()
    {
        gameObject.SetActive(false);
    }

    public virtual void BoxShot()
    {
        gameObject.SetActive(false);
    }

    public void ReactivateBox()
    {
        Invoke("DelayedReactivateBox", delayToReactivate);
    }

    public virtual void DelayedReactivateBox()
    {

        gameObject.SetActive(true);
        goldText.text = price.ToString() + " gold";
        if (player.isDead)
        {
            price = originalPrice;
            gameObject.SetActive(false);
        }
    }

}
