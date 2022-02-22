using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coins;

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoin()
    {
        count += 1;
        if (count < 10)
        {
            coins.SetText($"0{count}");
        }
        else
        {
            coins.SetText($"{count}");
        }
        
    }
}
