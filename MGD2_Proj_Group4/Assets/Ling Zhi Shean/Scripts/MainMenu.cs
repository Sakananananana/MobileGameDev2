using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text Total_Coins_Text;
    public int Total_Coins;
    public int Coins_Collected;

    // Start is called before the first frame update
    void Start()
    {
        Coins_Collected = PlayerPrefs.GetInt("Gameplay_Coins", 0);
        Total_Coins += Coins_Collected;
        PlayerPrefs.DeleteKey("Gameplay_Coins");

    }

    // Update is called once per frame
    void Update()
    {
        Total_Coins_Text.text = Total_Coins.ToString();
    }
}
