using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer Audio_Mixer;

    public int BGM_On;
    public GameObject BGM_Line;

    public int SFX_On;
    public GameObject SFX_Line;

    //Add PlayerPrefs

    // Start is called before the first frame update
    void Start()
    {
        BGM_On = PlayerPrefs.GetInt("BGM_On", 1);
        SFX_On = PlayerPrefs.GetInt("SFX_On", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (BGM_On == 0)
        {
            Audio_Mixer.SetFloat("BGM", -80);
            BGM_Line.SetActive(true);
        }
        else
        {
            Audio_Mixer.SetFloat("BGM", 0);
            BGM_Line.SetActive(false);
        }

        if (SFX_On == 0)
        {
            Audio_Mixer.SetFloat("SFX", -80);
            SFX_Line.SetActive(true);
        }
        else
        {
            Audio_Mixer.SetFloat("SFX", 0);
            SFX_Line.SetActive(false);
        }
    }

    public void BGM_Toggle()
    {
        if(BGM_On == 0)
        {
            PlayerPrefs.SetInt("BGM_On", 1);
            PlayerPrefs.Save();
            BGM_On = 1;
        }
        else
        {
            PlayerPrefs.SetInt("BGM_On", 0);
            PlayerPrefs.Save();
            BGM_On = 0;
        }
    }

    public void SFX_Toggle()
    {
        if (SFX_On == 0)
        {
            PlayerPrefs.SetInt("SFX_On", 1);
            PlayerPrefs.Save();
            SFX_On = 1;
        }
        else
        {
            PlayerPrefs.SetInt("SFX_On", 0);
            PlayerPrefs.Save();
            SFX_On = 0;
        }
    }
}
