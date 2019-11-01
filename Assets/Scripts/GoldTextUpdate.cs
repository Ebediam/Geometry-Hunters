using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldTextUpdate : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        player.GoldUpdateEvent += UpdateGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGold(int addedGold, int totalGold)
    {
        goldText.text = "Gold: " + totalGold.ToString();
    }
}
