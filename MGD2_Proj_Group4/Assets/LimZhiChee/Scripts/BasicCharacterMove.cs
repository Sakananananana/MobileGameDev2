using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicCharacterMove : MonoBehaviour
{
    //Script Declaration
    Rigidbody rb;
    GameController controller;

    //Variable Declaration
    public GameObject gameControl;
    Vector3 modifiedTorque;
    Vector3 moveForward;
    Vector3 tilting;
    Vector3 moveDirection;
    float tiltSpeed = 3.0f;
    float timeRemaining = 15.0f;
    float maxTime = 5f;
    float minTime = 2f;
    float tiltSelected;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get RB's component
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<GameController>();

        //Start the game with tilting to left or right
        tiltSelected = (Random.value < 0.5f) ? -0.5f : 0.5f;
        Vector3 tilting = new Vector3(0f, 0f, tiltSelected);
        rb.AddTorque(tilting, ForceMode.Force);

        //Start with random length of wind blow time
        timeRemaining = Random.Range(minTime, maxTime);

        //modifiedTorque = controller.modifiedTorque;
    }

    // Update is called once per frame
    void Update()
    {
        GameController controller = gameControl.GetComponent<GameController>();
        
        //float horizontalSpeed = Input.GetAxis("Horizontal") * tiltSpeed;
        //Vector3 moveDirection = new Vector3(0f, 0f, horizontalSpeed);

        if (transform.rotation.z > 0.3 || transform.rotation.z < -0.3)
        {
            unfreezePosition();
        }
        else 
        {
            playerMovement(controller.modifiedTorquee);
        }   
    }

    public void playerMovement(Vector3 modifiedTorque)
    {
        moveForward = transform.position.normalized;
        moveForward.y = 0;
        rb.velocity = moveForward + Vector3.forward * speed;

        if (transform.rotation.z > 0)
        {
            tilting = new Vector3(0f, 0f, 0.5f) + modifiedTorque;
            Debug.Log(modifiedTorque);
            rb.AddTorque(tilting, ForceMode.Force);
        }
        else
        {
            tilting = new Vector3(0f, 0f, -0.5f) + modifiedTorque;
            rb.AddTorque(tilting, ForceMode.Force);
        }
    }

    public void unfreezePosition() 
    {
        RigidbodyConstraints currentConstraints = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }
}
