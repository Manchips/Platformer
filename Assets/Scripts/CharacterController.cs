using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float maxRunSpeed = 6f;
    public float sprint = 10f;
    public float jumpForce = 20f;
    public float jumpBouns = 6f;
    private Animator animComp;
    
    private Rigidbody body;

    private Collider collider;

    public bool feetContact; 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float castDistance = collider.bounds.extents.y + 0.1f;
        feetContact  = Physics.Raycast(transform.position, Vector3.down, castDistance);
        
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetContact && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (body.velocity.y > 0f && Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpBouns, ForceMode.Force);
        }
        
        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newX = sprint * Mathf.Sign(body.velocity.x);
                body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
            }
        }
        
        //slows down so we don't drag as much 
        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
        
        animComp.SetFloat("Speed", body.velocity.magnitude);
    }
}
