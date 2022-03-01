using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
 
public class Respawn : MonoBehaviour {
 
    public GameObject spawnPoint;
   
    void OnTriggerEnter (Collider col)
    {
        if(col.transform.CompareTag("Lava") || col.transform.CompareTag("Goal"))
        {
            this.transform.position = spawnPoint.transform.position;
        }
    }
}
