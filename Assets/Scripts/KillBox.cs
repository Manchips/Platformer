using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public Rigidbody body;

    public bool hitOnce = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player died!");
            //FindObjectOfType<LevelParser>().ReloadLevel();
        }
    }
} 
