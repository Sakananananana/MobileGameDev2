using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // 3 coin spawn spots
    // choose one
    // behind spawn 3 more
    // current place spawn one transform.position += 2 spawn
    // collide destroy 
    // coin + 1

    private GameController gameController;

    public void Update()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            gameController.IncreaseCoinCount();
            Destroy(this.gameObject);
        }
    }

}
