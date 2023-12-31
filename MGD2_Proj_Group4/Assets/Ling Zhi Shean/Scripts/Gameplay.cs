using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public GameObject Character_1;
    public GameObject Character_2;
    public GameObject Character_3;

    public int Outfit1_isEquiped;
    public int Outfit2_isEquiped;
    public int Outfit3_isEquiped;

    CharacterMovement Character_Movement;
    public GameObject Player;
    public float Player_Original_Position;

    public TMP_Text Coins_Collected;
    public int Total_Coins_Collected;

    public float Traveled_Distance;
    public TMP_Text Gameplay_Distance;
    public TMP_Text GameOver_Distance;

    public GameObject PU1_Panel;
    public TMP_Text PU1_Timer_Text;
    public float PU1_Timer;

    public GameObject PU2_Panel;
    public TMP_Text PU2_Timer_Text;
    public float PU2_Timer;

    public GameObject GameOver_Panel;
    public float Longest_Traveled_Distance;
    public TMP_Text GameOver_Longest_Distance;

    public GameObject Warning_Panel;
    public int Warning_First_Time;

    public GameObject Tutorial_Panel;
    public int First_Time;

    // Start is called before the first frame update
    void Start()
    {
        Outfit1_isEquiped = PlayerPrefs.GetInt("Outfit1_isEquipped", 1);
        Outfit2_isEquiped = PlayerPrefs.GetInt("Outfit2_isEquipped", 0);
        Outfit3_isEquiped = PlayerPrefs.GetInt("Outfit3_isEquipped", 0);

        Character_Movement = Player.GetComponent<CharacterMovement>();

        PlayerPrefs.GetInt("Outfit1_isEquipped", 1);

        Player_Original_Position = Player.transform.position.z;

        PU1_Panel.SetActive(false);
        PU2_Panel.SetActive(false);

        PU1_Timer = Character_Movement.PU1Duration;
        PU2_Timer = Character_Movement.PU2Duration;

        GameOver_Panel.SetActive(false);

        Warning_First_Time = PlayerPrefs.GetInt("WarningFirst", 1);

        if(Warning_First_Time == 1)
        {
            Warning_Panel.SetActive(true);
            PlayerPrefs.SetInt("WarningFirst", 0);
            PlayerPrefs.Save();
        }
        

        First_Time = PlayerPrefs.GetInt("First_Time", 1);

        if (First_Time == 1)
        {
            Tutorial_Panel.SetActive(true);
        }

        Total_Coins_Collected = PlayerPrefs.GetInt("Gameplay_Coins");
    }

    // Update is called once per frame
    void Update()
    {
        if(Warning_Panel.activeSelf)
        {
            Time.timeScale = 0f;
        }

        if(Tutorial_Panel.activeSelf)
        {
            Time.timeScale = 0f;
        }

        if (Outfit1_isEquiped == 1)
        {
            Character_1.SetActive(true);
            Character_2.SetActive(false);
            Character_3.SetActive(false);
        }

        if (Outfit2_isEquiped == 1)
        {
            Character_2.SetActive(true);
            Character_1.SetActive(false);
            Character_3.SetActive(false);
        }

        if (Outfit3_isEquiped == 1)
        {
            Character_3.SetActive(true);
            Character_1.SetActive(false);
            Character_2.SetActive(false);
        }


        Coins_Collected.text = "x" + Character_Movement.coinNum;


        Traveled_Distance = Player.transform.position.z - Player_Original_Position;
        Gameplay_Distance.text = Traveled_Distance.ToString("0.0") + "m";


        PU1_Timer_Text.text = PU1_Timer.ToString("00") + "s";
        PU2_Timer_Text.text = PU2_Timer.ToString("00") + "s";

        if (Character_Movement.isPU1)
        {
            PU1_Panel.SetActive(true);
            PU1_Timer -= Time.deltaTime;
        }
        else
        {
            PU1_Panel.SetActive(false);
            PU1_Timer = Character_Movement.PU1Duration;
        }

        if (Character_Movement.isPU2)
        {
            PU2_Panel.SetActive(true);
            PU2_Timer -= Time.deltaTime;
        }
        else
        {
            PU2_Panel.SetActive(false);
            PU2_Timer = Character_Movement.PU2Duration;
        }

        if (Character_Movement.isDeath)
        {
            Longest_Traveled_Distance = PlayerPrefs.GetFloat("Longest_Distance");

            if (Traveled_Distance > Longest_Traveled_Distance)
            {
                Longest_Traveled_Distance = Traveled_Distance;
                PlayerPrefs.SetFloat("Longest_Distance", Longest_Traveled_Distance);
                PlayerPrefs.Save();
            }

            GameOver_Distance.text = Traveled_Distance.ToString("0.0") + "m";
            GameOver_Longest_Distance.text = Longest_Traveled_Distance.ToString("0.0") + "m";
            GameOver_Panel.SetActive(true);
        }
    }

    public void WaningPanel()
    {
        Warning_Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TutorialPanel()
    {
        Tutorial_Panel.SetActive(false);
        PlayerPrefs.SetInt("First_Time", 0);
        PlayerPrefs.Save();
    }

    public void Restart()
    {
        Total_Coins_Collected += Character_Movement.coinNum;
        PlayerPrefs.SetInt("Gameplay_Coins", Total_Coins_Collected);
        PlayerPrefs.Save();
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("Gameplay_Coins", Character_Movement.coinNum);
        PlayerPrefs.Save();
    }
}
