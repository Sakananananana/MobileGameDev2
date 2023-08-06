using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject volumePanel;

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Pause Menu");
    }
}