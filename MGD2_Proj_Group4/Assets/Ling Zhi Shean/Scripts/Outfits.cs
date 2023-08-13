using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Outfits : MonoBehaviour
{
    MainMenu Main_Menu;

    public Button Outfit1_Button;
    public TMP_Text Outfit1_Text;
    public int Outfit1_isPurchased;
    public int Outfit1_isEquiped;

    public Button Outfit2_Button;
    public TMP_Text Outfit2_Text;
    public int Outfit2_isPurchased;
    public int Outfit2_isEquiped;

    public Button Outfit3_Button;
    public TMP_Text Outfit3_Text;
    public int Outfit3_isPurchased;
    public int Outfit3_isEquiped;

    // Start is called before the first frame update
    void Start()
    {
        Main_Menu = GetComponent<MainMenu>();

        Outfit1_isPurchased = PlayerPrefs.GetInt("Outfit1_isPurchased", 1);
        Outfit1_isEquiped = PlayerPrefs.GetInt("Outfit1_isEquipped", 1);

        Outfit2_isPurchased = PlayerPrefs.GetInt("Outfit2_isPurchased", 0);
        Outfit2_isEquiped = PlayerPrefs.GetInt("Outfit2_isEquipped", 0);

        Outfit3_isPurchased = PlayerPrefs.GetInt("Outfit3_isPurchased", 0);
        Outfit3_isEquiped = PlayerPrefs.GetInt("Outfit3_isEquipped", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Outfit1_isEquiped == 0 && Outfit1_isPurchased == 0)
        {
            Outfit1_Button.interactable = true;
            Outfit1_Text.text = "Tap to Purchase (5 coins)";
        }
        else if(Outfit1_isEquiped == 0 && Outfit1_isPurchased == 1)
        {
            Outfit1_Button.interactable = true;
            Outfit1_Text.text = "Tap to Equip";
        }
        else
        {
            Outfit1_Button.interactable = false;
            Outfit1_Text.text = "Equipped";
        }


        if(Outfit2_isEquiped == 0 && Outfit2_isPurchased == 0)
        {
            Outfit2_Button.interactable = true;
            Outfit2_Text.text = "Tap to Purchase (5 coins)";
        }
        else if (Outfit2_isEquiped == 0 && Outfit2_isPurchased == 1)
        {
            Outfit2_Button.interactable = true;
            Outfit2_Text.text = "Tap to Equip";
        }
        else
        {
            Outfit2_Button.interactable = false;
            Outfit2_Text.text = "Equipped";
        }


        if (Outfit3_isEquiped == 0 && Outfit3_isPurchased == 0)
        {
            Outfit3_Button.interactable = true;
            Outfit3_Text.text = "Tap to Purchase (5 coins)";
        }
        else if (Outfit3_isEquiped == 0 && Outfit3_isPurchased == 1)
        {
            Outfit3_Button.interactable = true;
            Outfit3_Text.text = "Tap to Equip";
        }
        else
        {
            Outfit3_Button.interactable = false;
            Outfit3_Text.text = "Equipped";
        }
    }

    public void Outfit1_Update()
    {
        if(Outfit1_isPurchased == 0 && Main_Menu.Total_Coins >= 5)
        {
            PlayerPrefs.SetInt("Outfit1_isPurchased", 1);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 5;
            Outfit1_isPurchased = 1;
        }
        else if(Outfit1_isEquiped == 0 && Outfit1_isPurchased == 1)
        {
            PlayerPrefs.SetInt("Outfit2_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit3_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit1_isEquipped", 1);
            PlayerPrefs.Save();
            Outfit2_isEquiped = 0;
            Outfit3_isEquiped = 0;
            Outfit1_isEquiped = 1;
        }
    }

    public void Outfit2_Update()
    {
        if (Outfit2_isPurchased == 0 && Main_Menu.Total_Coins >= 5)
        {
            Outfit2_Text.text = "Press to Equip";
            PlayerPrefs.SetInt("Outfit2_isPurchased", 1);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 5;
            Outfit2_isPurchased = 1;
        }
        else if (Outfit2_isEquiped == 0 && Outfit2_isPurchased == 1)
        {
            PlayerPrefs.SetInt("Outfit1_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit3_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit2_isEquipped", 1);
            PlayerPrefs.Save();
            Outfit1_isEquiped = 0;
            Outfit3_isEquiped = 0;
            Outfit2_isEquiped = 1;
        }
    }

    public void Outfit3_Update()
    {
        if (Outfit3_isPurchased == 0 && Main_Menu.Total_Coins >= 5)
        {
            Outfit3_Text.text = "Press to Equip";
            PlayerPrefs.SetInt("Outfit3_isPurchased", 1);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 5;
            Outfit3_isPurchased = 1;
        }
        else if (Outfit3_isEquiped == 0 && Outfit3_isPurchased == 1)
        {
            PlayerPrefs.SetInt("Outfit1_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit2_isEquipped", 0);
            PlayerPrefs.SetInt("Outfit3_isEquipped", 1);
            PlayerPrefs.Save();
            Outfit1_isEquiped = 0;
            Outfit2_isEquiped = 0;
            Outfit3_isEquiped = 1;
        }
    }
}
