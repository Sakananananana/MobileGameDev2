using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEndBehaviour : MonoBehaviour
{
    private GameController gameController;
    float destroyTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.IncreasePassCount();

            //Spawn new tile if player collide with tile end,
            GameObject.FindObjectOfType<GameController>().SpawnRope();


            //and destroy the previous tile
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}
