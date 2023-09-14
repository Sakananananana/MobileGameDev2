using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 80f);
    }
}