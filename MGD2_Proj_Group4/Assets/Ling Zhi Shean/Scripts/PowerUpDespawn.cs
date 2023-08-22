using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDespawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
