using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.DeathEvent += Activate;
        player.RestartEvent += OnRestart;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void OnRestart()
    {
        gameObject.SetActive(false);
    }


}
