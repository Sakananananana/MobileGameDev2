using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Gameplay UI");
    }
}