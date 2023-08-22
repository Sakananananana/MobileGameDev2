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

        Coins_Collected = PlayerPrefs.GetInt("Gameplay_Coins", 0);
        Total_Coins += Coins_Collected;
        PlayerPrefs.DeleteKey("Gameplay_Coins");
    }

    // Update is called once per frame
    void Update()
    {
        if(outfit.Outfit1_isEquiped == 1)
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

        Total_Coins_Text.text = "x" + Total_Coins.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay UI");
    }
}
