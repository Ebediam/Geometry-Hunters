using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{

    public WaveManager waveManager;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        waveManager.WaveEndEvent += UpdateText;
        waveManager.player.RestartEvent += ResetText;
    }

    void UpdateText()
    {
        text.text = "Wave: " + waveManager.wavesCompleted.ToString();
    }
    // Update is called once per frame
    void ResetText()
    {
        text.text = "Wave: 0";
    }
}
