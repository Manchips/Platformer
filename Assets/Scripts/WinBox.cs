using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public Rigidbody body;
    public bool hitOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        //Both this and the lava failed to work so I took them out for the time being 
        //if (collision.collider.CompareTag("Player") && !hitOnce)
        //{
        Debug.Log("Player Won!");
        //FindObjectOfType<LevelParser>().ReloadLevel();    
        //}else if (hitOnce)
        //{
        //hitOnce = false; 
        //}
    }
}
