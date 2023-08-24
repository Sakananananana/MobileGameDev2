using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private GameController gameController;
    private PowerUpBehaviour powerUP;

    // Update is called once per frame
    void Update()
    {
        powerUP = GetComponent<PowerUpBehaviour>();
    }

    void OnCollisionEnter (Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
