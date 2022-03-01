using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//I wonder if I can actually make the weird super fast seconds in og mario, should ask about it l8r 

public class TimeManager : MonoBehaviour
{
    public float timeValue; 
    public TextMeshProUGUI time; 
    
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 100; //Set and reset time back to 100 at the start of the game 
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime; //subtract 1 second about every frame 
        }
        else
        {
            timeValue = 0; 
            Start(); //Restart time later on I should make a call to the game manager to reset the entire game as well
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeValue)
    {
        if (timeValue < 0)
        {
            timeValue = 0; //If we get under zero cause of rounding just show 0 
            Start(); //Restart time later on I should make a call to the game manager to reset the entire game as well 
        }

        timeValue = Mathf.FloorToInt(timeValue); //this will round it down to seconds! 
        time.text = $"{timeValue}";
    }
}
