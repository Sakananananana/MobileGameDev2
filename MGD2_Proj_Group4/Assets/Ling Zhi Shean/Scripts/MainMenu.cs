using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    Outfits outfit;

    public GameObject Character_1;
    public GameObject Character_2;
    public GameObject Character_3;

    public TMP_Text Total_Coins_Text;
    public int Total_Coins;
    public int Coins_Collected;

    // Start is called before the first frame update
    void Start()
    {
        outfit = GetComponent<Outfits>();

        Total_Coins = PlayerPrefs.GetInt("Total_Coins", 0);
        Coins_Collected = PlayerPrefs.GetInt("Gameplay_Coins");
        Total_Coins += Coins_Collected;
        PlayerPrefs.SetInt("Total_Coins", Total_Coins);
        PlayerPrefs.SetInt("Gameplay_Coins", 0);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("WarningFirst", 1);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        Total_Coins_Text.text = "x" + Total_Coins.ToString();
        PlayerPrefs.SetInt("Total_Coins", Total_Coins);
        PlayerPrefs.Save();

        if (outfit.Outfit1_isEquiped == 1)
        {
            Character_1.SetActive(true);
            Character_2.SetActive(false);
            Character_3.SetActive(false);
        }

        if (outfit.Outfit2_isEquiped == 1)
        {
            Character_2.SetActive(true);
            Character_1.SetActive(false);
            Character_3.SetActive(false);
        }

        if (outfit.Outfit3_isEquiped == 1)
        {
            Character_3.SetActive(true);
            Character_1.SetActive(false);
            Character_2.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay UI");
    }
}
