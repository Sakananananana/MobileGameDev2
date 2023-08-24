using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    //GameController gameController;
    int chosenPower = 0;
    bool buffActivated = false;
    bool breakBuff = false;
    float timeRemaining = 5;

    // Update is called once per frame
    void Update()
    {
        //gameController = FindObjectOfType<GameController>();

        //if (breakBuff)
        //{ 
        //    buffActivated = true;
        //}

        //if (buffActivated == true)
        //{
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log(timeRemaining);
            //Debug.Log(buffActivated);
        }
        //}
        //else if (timeRemaining < 0)
        //{
        //    buffActivated = false;
        //    timeRemaining = 5.0f;
        //}
    }

    private void FixedUpdate()
    {
       
            if (timeRemaining > 0)
            {
               // timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
                //Debug.Log(buffActivated);
            }
        
    }
    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        chosenPower = Random.Range(2, 3);
    //        buffActivated = true;
    //        //switch (chosenPower) 
    //        //{
    //        //    case 1:
    //        //    {
    //        //        Debug.Log("NUMBER 1 BUFF IS CHOSEN");  
    //        //    }
    //        //    break;

    //        //    case 2:
    //        //    {
    //        //        buffActivated = true; 
    //        //        Debug.Log(buffActivated);
    //        //        Debug.Log("NUMBER 2 BUFF IS CHOSEN");
    //        //    }
    //        //    break;
    //        //}
    //    }
    //}
}
