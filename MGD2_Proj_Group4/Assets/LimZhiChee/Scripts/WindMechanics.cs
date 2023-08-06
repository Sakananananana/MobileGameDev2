using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WindMechanics : MonoBehaviour
{
    Rigidbody rb;
    private FixedJoint joint;
    public GameObject originObj;
    float maxWindStrength = 1.5f;
    float timeRemaining = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
        }
        else
        {
            windMechanic();
            Invoke("timerReset", 0.5f);

        }
        //rb = GameObject.Find("Capsule").GetComponent<Rigidbody>();
    }

    public void windMechanic()
    {
        if (timeRemaining < 0)
        {
            Debug.Log("wind blown");
        }

        //random a direction left right (ok
        //random a windspeed (ok
        //clamp rotation 
        //add force to the character


        // Simulate random wind force (simplified example)
        Vector3 windForce = new Vector3(0f, 0f, Random.Range(-maxWindStrength, maxWindStrength));
       
        // Apply the wind force as a random torque to the character's Rigidbody
        rb.AddTorque(windForce * Time.deltaTime, ForceMode.Impulse);

    }

    public void timerReset()
    {
        timeRemaining = 5.0f;
    }
}
