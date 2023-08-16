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
    Rigidbody rb;

    //wind strength related
    public Vector3 modifiedTorquee;
    public Vector3 windModifier = new Vector3(0f, 0f, 0f);
    public float chosenWindPower;
    float[] WindPower = {-2.5f, -1.5f, -1f, 1f, 1.5f, 2.5f};

    //next time the wind blow
    float timeRangeMin = 10.0f;
    float timeRangeMax = 15.0f;
    public float timeRemaining = 10.0f;

    //the time of the wind cast on player
    float timeCastMin = 3f;
    float timeCastMax = 5f;
    float castTimeRemaining;

    bool modified = true;
    bool inCast = false;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn 5 unit of rope at start
        for (var i = 0; i < 5; i++)
        {
            SpawnRope();
        }

        //Random wind spawn at start
        castTimeRemaining = Random.Range(timeCastMin, timeCastMax);
    }

    // Update is called once per frame
    public void Update()
    {
        if (timeRemaining > 0)
        {
            //when timeRemain is more than 0 -= Time.deltaTime
            timeRemaining -= Time.deltaTime;

            //modified = true, means already modified dun wan change
            modified = true;
        }
        else
        {
            //time finish counting modified = false means need new wind power
            modified = false;  
        }

        if (modified == false && timeRemaining < 0)
        {
            modifiedTorquee = windMechanic();
            castTimeRemaining = Random.Range(timeCastMin, timeCastMax);
            inCast = true;
            timerReset();
            modified = true;
        }
        if (castTimeRemaining > 0 && modifiedTorquee.z != 0)
        {
            castTimeRemaining -= Time.deltaTime;
            Debug.Log(modifiedTorquee);
            Debug.Log(castTimeRemaining);
        }
        else if (inCast == true)
        {
            modifiedTorquee = new Vector3(0, 0, 0);
            inCast = false;
        }

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

            Transform newCoins = Instantiate(coins, spawnPos, Quaternion.identity);
            newCoins.SetParent(spawnPoint.transform);
        }
    }

    public void IncreaseCoinCount()
    {
        coinCount++;
        Debug.Log("Collected coins: " + coinCount);
    }

    public Vector3 windMechanic()
    {
        chosenWindPower = WindPower[Random.Range(0, WindPower.Length)];
        windModifier = new Vector3(0f, 0f, chosenWindPower);
        return windModifier;
    }

    public void timerReset()
    {
        timeRemaining = Random.Range(timeRangeMin, timeRangeMax);
    }
}
