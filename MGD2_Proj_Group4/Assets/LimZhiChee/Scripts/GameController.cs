using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Variable
    public Transform ropee;
    //public GameObject tileEnd;

    public Vector3 nextTile;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 3; i++)
        {
            SpawnRope();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRope()
    {
        Transform newTile = Instantiate(ropee, nextTile, Quaternion.identity);

        Transform next = newTile.Find("SpawnPoint");
        nextTile = next.position;
    }


}
