using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnLoop : MonoBehaviour
{
    public Transform Player_Location;

    public Vector3 Ground_Spawn_Point;
    public Transform Ground_Spawn_Reference_Point;

    public GameObject[] Ground_Type;

    // Start is called before the first frame update
    void Start()
    {
        Ground_Spawn_Point = new Vector3(0f, -24.4f, 70f);
        Instantiate(Ground_Type[0], Ground_Spawn_Point, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Location.position.z >= Ground_Spawn_Reference_Point.position.z)
        {
            Ground_Spawn_Reference_Point.position = Ground_Spawn_Point;
            Ground_Spawn_Point = new Vector3(0f, Ground_Spawn_Point.y, Ground_Spawn_Point.z + 137.25f);

            if (Player_Location.position.z < 200f)
            {
                Instantiate(Ground_Type[0], Ground_Spawn_Point, Quaternion.identity);
            }
            else if (Player_Location.position.z < 600f)
            {
                Instantiate(Ground_Type[1], Ground_Spawn_Point, Quaternion.identity);
            }
            else
            {
                Instantiate(Ground_Type[2], Ground_Spawn_Point, Quaternion.identity);
            }
        }
    }
}
