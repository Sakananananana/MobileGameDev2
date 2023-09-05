using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private GameController gameController;
    private BasicCharacterMove CharaMove;

    // Update is called once per frame
    void Update()
    {
        CharaMove = FindObjectOfType<BasicCharacterMove>();
        if (CharaMove.breakBuff)
        {
            //Debug.Log("Enabled");
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && CharaMove.breakBuff)
        {
            Debug.Log("Break");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && CharaMove.breakBuff == false)
        {
            Debug.Log("collided");
        }
    }

}
