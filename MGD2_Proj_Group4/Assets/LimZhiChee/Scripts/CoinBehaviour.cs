using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
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
