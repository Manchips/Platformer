using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Destory : MonoBehaviour
{
    public float distance = 1.5f; //1.5 is just right  
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rbody = GetComponent<Rigidbody>();

        StartCoroutine(UpdatePickingRaycast());
    }

    IEnumerator UpdatePickingRaycast()
    {
        while (true)
        {
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition); //grabs mouse position and uses that for the ray 
            if(Physics.Raycast(mouse,out RaycastHit hitInfo))
            {
                float l = 3;
                Debug.DrawLine(hitInfo.point + Vector3.left * l, hitInfo.point + Vector3.right * l, Color.magenta); //We probably don't need this since its a 2d game
                Debug.DrawLine(hitInfo.point + Vector3.up * l, hitInfo.point + Vector3.down * l, Color.magenta);
                if (Input.GetMouseButton(0))
                {
                    if (hitInfo.collider.gameObject == gameObject)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            
            

            yield return null; //just gives up 1 frame for the infinite loop 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down); //we want the raycast to go down we don't care if mario jumps on top 

        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            Debug.DrawRay(transform.position,Vector3.down * distance,Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position,Vector3.down * distance,Color.blue);
        }
        
    }
    
}
