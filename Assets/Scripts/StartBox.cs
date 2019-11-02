using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{

    public delegate void StartDelegate();

    public StartDelegate StartEvent;

    public WaveManager waveManager;

    public float delayToReactivate;

    public BlockSettings myBlock;

    public Player player;

    public void Start()
    {
        waveManager.WaveEndEvent += ReactivateBox;
        myBlock.OnCollisionEvent += StartGame;
        player.RestartEvent += DelayedReactivateBox;

    }

    public void ReactivateBox()
    {
        Invoke("DelayedReactivateBox", delayToReactivate);
    }

    public void DelayedReactivateBox()
    {
        gameObject.SetActive(true);
    }


    public void StartGame()
    {
        StartEvent();
        gameObject.SetActive(false);
       
    }
}
