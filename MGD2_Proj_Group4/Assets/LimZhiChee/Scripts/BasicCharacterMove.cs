using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicCharacterMove : MonoBehaviour
{
    //Script Declaration
    Rigidbody rb;
    GameController controller;
    PowerUpBehaviour powerUp;

    //Variable Declaration
    public GameObject gameControl;
    Vector3 modifiedTorque;
    Vector3 moveForward;
    Vector3 tilting;
    Vector3 moveDirection;
    float horizontalSpeed;
    float tiltSpeed = 1.0f; 
    float timeRemaining = 15.0f;
    float maxTime = 5f;
    float minTime = 2f;
    float tiltSelected;
    float speed = 3.0f;

    //Power Up
    float powerTimeRemaining = 5.0f;
    bool buffActivated = false;
    bool stableBuff = false;
    public bool breakBuff = false;
    int chosenPower;

    public enum MobileHorizMovement
    {
        Accelerometer,
        ScreenTouch
    }
    public MobileHorizMovement horizMovement = MobileHorizMovement.Accelerometer;

    // Start is called before the first frame update
    void Start()
    {
        //Get RB's component
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<GameController>();

        //Start the game with tilting to left or right
        //tiltSelected = (Random.value < 0.5f) ? -0.5f : 0.5f;
        //Vector3 tilting = new Vector3(0f, 0f, tiltSelected);
        //rb.AddTorque(tilting, ForceMode.Force);

        //Start with random length of wind blow time
        timeRemaining = Random.Range(minTime, maxTime);

    }

    // Update is called once per frame
    void Update()
    {
        GameController controller = gameControl.GetComponent<GameController>();

        horizontalSpeed = Input.GetAxis("Horizontal") * tiltSpeed;
        moveDirection = new Vector3(0f, 0f, horizontalSpeed);
        rb.AddTorque(moveDirection);

        if (horizMovement == MobileHorizMovement.Accelerometer)
        {
            //Move player based on direction of the accelerometer
            horizontalSpeed = Input.GetAxis("Horizontal") * tiltSpeed;
            moveDirection = new Vector3(0f, 0f, horizontalSpeed);
            rb.AddTorque(moveDirection);
        }

        if (transform.rotation.z > 0.4 || transform.rotation.z < -0.4)
        {
            unfreezePosition();
        }
        else if (stableBuff == true)
        {
            movingForward();

        }
        else
        {
            movingForward();
            playerMovement(controller.modifiedTorquee);
        }   
    }

    private void FixedUpdate()
    {
        if (powerTimeRemaining > 0 && buffActivated)
        {
            powerTimeRemaining -= Time.deltaTime;
        }
        else
        { 
            buffActivated = false;

            if (breakBuff)
            { 
                breakBuff = false;
            }
            if (stableBuff)
            {
                stableBuff = false;
            }

            powerTimeRemaining = 5.0f;   
        }
    }

    public void playerMovement(Vector3 modifiedTorque)
    {
        if (transform.rotation.z > 0)
        {
            tilting = new Vector3(0f, 0f, 0.5f) + modifiedTorque;
            rb.AddTorque(tilting, ForceMode.Force);
        }
        else
        {
            tilting = new Vector3(0f, 0f, -0.5f) + modifiedTorque;
            rb.AddTorque(tilting, ForceMode.Force); 
        }
    }

    public void movingForward()
    {
        moveForward = transform.position.normalized;
        moveForward.y = 0;
        rb.velocity = moveForward + Vector3.forward * speed;
    }

    public void unfreezePosition() 
    {
        RigidbodyConstraints currentConstraints = rb.constraints;
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }

    public void playerBuff()
    {
        chosenPower = Random.Range(1, 2);
        switch (chosenPower)
        {
            case 1:
                {
                    buffActivated = true;
                    stableBuff = true;
                    Debug.Log("Stable");
                }
                break;

            case 2:
                {
                    buffActivated = true;
                    breakBuff = true;
                }
                break;
        }

    }

}
