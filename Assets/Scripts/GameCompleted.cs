using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleted : MonoBehaviour
{

    public WaveManager waveManager;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        waveManager.GameEndEvent += Activate;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        Invoke("Deactivate", 4f);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
