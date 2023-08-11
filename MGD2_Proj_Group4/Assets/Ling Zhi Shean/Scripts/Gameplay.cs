using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gameplay : MonoBehaviour
{
    BasicCharacterMove Character_Movement;
    public GameObject Player;
    public float Player_Original_Position;

    public TMP_Text Coins_Collected;

    public float Traveled_Distance;
    public TMP_Text Gameplay_Distance;
    public TMP_Text GameOver_Distance;

    public GameObject PU1_Panel;
    public TMP_Text PU1_Timer_Text;
    public int PU1_Timer;

    public GameObject PU2_Panel;
    public TMP_Text PU2_Timer_Text;
    public int PU2_Timer;

    public GameObject GameOver_Panel;
    public float Longest_Traveled_Distance;
    public TMP_Text GameOver_Longest_Distance;

    // Start is called before the first frame update
    void Start()
    {
        Character_Movement = Player.GetComponent<BasicCharacterMove>();

        Player_Original_Position = Player.transform.position.z;

        PU1_Panel.SetActive(false);
        PU2_Panel.SetActive(false);

        PU1_Timer = PlayerPrefs.GetInt("PU1_Duration");
        PU2_Timer = PlayerPrefs.GetInt("PU2_Duration");

        GameOver_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Coins_Collected = Character_Movement.coinCount;

        Traveled_Distance = Player.transform.position.z - Player_Original_Position;
        Gameplay_Distance.text = Traveled_Distance.ToString(".0");


        PU1_Timer_Text.text = PU1_Timer.ToString("00");
        PU2_Timer_Text.text = PU2_Timer.ToString("00");

        //if (Character_Movement.isPU1)
        //{
        //    PU1_Panel.SetActive(true);
        //    PU1_Timer--;
        //}
        //else if (Pu1_Timer = 0)
        //{
        //    Character_Movement.isPU1 = false;
        //    PU1_Panel.SetActive(false);
        //    PU1_Timer = PlayerPrefs.GetInt("PU1_Duration");
        //}

        //if (Character_Movement.isPU2)
        //{
        //    PU2_Panel.SetActive(true);
        //    PU2_Timer--;
        //}
        //else if (PU2_Timer = 0)
        //{
        //    Character_Movement.isPU2 = false;
        //    PU2_Panel.SetActive(false);
        //    PU2_Timer = PlayerPrefs.GetInt("PU2_Duration");
        //}

        //if (Character_Movement.isDeath)
        //{
        //    PlayerPrefs.SetInt("Gameplay_Coins", Coins_Collected);
        //    PlayerPrefs.Save();

        //    Longest_Traveled_Distance = PlayerPrefs.GetFloat("Longest_Distance");

        //    if (Traveled_Distance > Longest_Traveled_Distance)
        //    {
        //        Longest_Traveled_Distance = Traveled_Distance;
        //        PlayerPrefs.SetFloat("Longest_Distance", Longest_Traveled_Distance);
        //        PlayerPrefs.Save();
        //    }

        //    GameOver_Distance.text = Traveled_Distance.ToString(".0");
        //    GameOver_Longest_Distance.text = Longest_Traveled_Distance.ToString(".0");
        //    GameOver_Panel.SetActive(true);
        //}
    }
}
