using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

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
    public void addPoint()
    {
        count += 100;
        {
            score.SetText($"00{count}");
        }
    }
    public void restart()
    {
        count = 0;
        score.SetText($"00{count}");
    }
}
