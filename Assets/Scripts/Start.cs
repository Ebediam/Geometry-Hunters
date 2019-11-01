using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{

    public delegate void StartDelegate();

    public StartDelegate StartEvent;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartGame();
    }

    public void StartGame()
    {
        StartEvent();
        gameObject.SetActive(false);
       
    }
}
