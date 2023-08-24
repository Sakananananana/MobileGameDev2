using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    BasicCharacterMove CharaMove;
    
    // Update is called once per frame
    void Update()
    {
        CharaMove = FindObjectOfType<BasicCharacterMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharaMove.playerBuff();
        }
    }
}
