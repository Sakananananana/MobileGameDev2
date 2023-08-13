using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    MainMenu Main_Menu;

    public Button PU1_Button;
    public TMP_Text PU1_Button_Text;
    public Image PU1_Upgrade_1;
    public Image PU1_Upgrade_2;
    public int PU1_Upgrade_State;

    public Button PU2_Button;
    public TMP_Text PU2_Button_Text;
    public Image PU2_Upgrade_1;
    public Image PU2_Upgrade_2;
    public int PU2_Upgrade_State;

    // Start is called before the first frame update
    void Start()
    {
        Main_Menu = GetComponent<MainMenu>();

        PU1_Upgrade_State = PlayerPrefs.GetInt("PU1_Upgrade_State", 0);
        PU2_Upgrade_State = PlayerPrefs.GetInt("PU2_Upgrade_State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PU1_Upgrade_State == 0)
        {
            PU1_Button_Text.text = "5 coins";
        }
        else if (PU1_Upgrade_State == 1)
        {
            PU1_Upgrade_1.color = Color.green;
            PU1_Button_Text.text = "10 coins";
        }
        else
        {
            PU1_Button.interactable = false;
            PU1_Upgrade_1.color = Color.green;
            PU1_Upgrade_2.color = Color.green;
            PU1_Button_Text.text = "Full Upgraded";
        }

        if (PU2_Upgrade_State == 0)
        {
            PU2_Button_Text.text = "5 coins";
        }
        else if (PU2_Upgrade_State == 1)
        {
            PU2_Upgrade_1.color = Color.green;
            PU2_Button_Text.text = "10 coins";
        }
        else
        {
            PU2_Button.interactable = false;
            PU2_Upgrade_1.color = Color.green;
            PU2_Upgrade_2.color = Color.green;
            PU2_Button_Text.text = "Full Upgraded";
        }
    }

    public void PU1_Upgrade()
    {
        if(PU1_Upgrade_State == 0 && Main_Menu.Total_Coins >= 5)
        {
            PlayerPrefs.SetInt("PU1_Upgrade_State", 1);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 5;
            PU1_Upgrade_State = 1;
        }
        else if(PU1_Upgrade_State == 1 && Main_Menu.Total_Coins >= 10)
        {
            PlayerPrefs.SetInt("PU1_Upgrade_State", 2);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 10;
            PU1_Upgrade_State = 2;
        }
    }

    public void PU2_Upgrade()
    {
        if (PU2_Upgrade_State == 0 && Main_Menu.Total_Coins >= 5)
        {
            PlayerPrefs.SetInt("PU2_Upgrade_State", 1);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 5;
            PU2_Upgrade_State = 1;
        }
        else if (PU2_Upgrade_State == 1 && Main_Menu.Total_Coins >= 10)
        {
            PlayerPrefs.SetInt("PU2_Upgrade_State", 2);
            PlayerPrefs.Save();
            Main_Menu.Total_Coins -= 10;
            PU2_Upgrade_State = 2;
        }
    }
}
