using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveForward;
    float speed = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    public void playerMovement()
    {
        moveForward = transform.position.normalized;
        moveForward.y = 0;
        rb.velocity = moveForward + Vector3.forward * speed;    
    }

}
