using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public Rigidbody body;
    public bool hitOnce = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !hitOnce)
        {
            Debug.Log("Player Won!");
            FindObjectOfType<LevelParser>().ReloadLevel();    
        }else if (hitOnce)
        {
            hitOnce = false; 
        }
    }
}
