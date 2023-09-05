using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    BasicCharacterMove CharaMove;
    string collidedObject;
    
    // Update is called once per frame
    void Update()
    {
        CharaMove = FindObjectOfType<BasicCharacterMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           collidedObject = this.gameObject.name;
 
            if (collidedObject == "Balancing(Clone)")
            {
                Debug.Log("collided");
                CharaMove.StableBuff();
            }

            if (collidedObject == "Invulnerable(Clone)")
            {
                Debug.Log("collided");
                CharaMove.BreakBuff();
            }
        }
    }
}
