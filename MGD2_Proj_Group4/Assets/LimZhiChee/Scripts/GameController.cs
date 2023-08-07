using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Variable
    public static GameController instance;
    public Transform ropee;
    public Transform coins;
    public Vector3 nextTile;
    public int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 5; i++)
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

        SpawnCoin(newTile);
    }

    public void SpawnCoin(Transform newTile)
    {
        List<GameObject> coinSpawnPoint = new List<GameObject>();

        foreach (Transform child in newTile)
        {
            if (child.CompareTag("CoinSpawn"))
            {
                coinSpawnPoint.Add(child.gameObject);
            }
        }

        if (coinSpawnPoint.Count > 0)
        {
            //randomly choose a spawn point based on right/center/left
            GameObject spawnPoint = coinSpawnPoint[Random.Range(0, coinSpawnPoint.Count)];

            //store the chosen spawn point
            Vector3 spawnPos = spawnPoint.transform.position;

            Transform newObstacle = Instantiate(coins, spawnPos, Quaternion.identity);
            newObstacle.SetParent(spawnPoint.transform);
        }
    }

    public void IncreaseCoinCount()
    {
        coinCount++;
        Debug.Log("Collected coins: " + coinCount);
    }
}
