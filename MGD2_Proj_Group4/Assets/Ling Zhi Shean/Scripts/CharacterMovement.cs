using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    public bool isDeath;

    public float forwardSpeed;

    public int coinNum;

    [Header("Tilt")]
    public float tiltRotation;
    public float tiltDirection;
    public float tiltSpeed;

    [Header("Unbalance")]
    public float unbalanceRotation;
    public float unbalanceDirection;
    public float unbalanceSpeed;
    public float oriUnbalanceSpeed;

    [Header("Wind Blow")]
    public bool isWindBlow;
    public int windDirectionRand;
    public float windRotation;
    public float windDirection;
    public float windSpeed;
    public float WindDuration;
    public float windOriTimer;
    public float windCountdownTimer;
    public GameObject warningSign;
    public bool isWarning;

    [Header("Power Up")]
    public int PU1_Upgrade_State;
    public float PU1Duration;
    public bool isPU1;
    
    public int PU2_Upgrade_State;
    public float PU2Duration;
    public bool isPU2;
    
    [Header("Outfits")]
    public int Outfit1_isEquiped;
    public bool isOutfit1;
    public int Outfit2_isEquiped;
    public bool isOutfit2;
    public int Outfit3_isEquiped;
    public bool isOutfit3;

    [Header("Audio")]
    public AudioSource BGMAudio;
    public AudioClip[] BGMAudioClip;
    public AudioSource SFXAudio;
    public AudioClip[] SFXAudioClip;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isDeath = false;

        isWindBlow = false;
        windCountdownTimer = windOriTimer;

        BGMAudio.panStereo = 0;
        BGMAudio.clip = BGMAudioClip[0];
        BGMAudio.Play();

        PU1_Upgrade_State = PlayerPrefs.GetInt("PU1_Upgrade_State", 0);
        PU2_Upgrade_State = PlayerPrefs.GetInt("PU2_Upgrade_State", 0);

        Outfit1_isEquiped = PlayerPrefs.GetInt("Outfit1_isEquipped", 0);
        Outfit2_isEquiped = PlayerPrefs.GetInt("Outfit2_isEquipped", 0);
        Outfit3_isEquiped = PlayerPrefs.GetInt("Outfit3_isEquipped", 0);

        powerupDuration();
        outfitEquipped();

        warningSign.SetActive(false); 
        isWarning = false;
    }

    // Update is called once per frame
    void Update()
    {
        FixedCharacterPosition();
        Dead();

        PowerUpEffect();
        OutfitEffect();

        if (Time.timeScale == 1)
        {
            Tilting();
            Unbalance();
            WindBlowTimer();
            transform.Rotate(0, 0, tiltRotation + (windRotation + unbalanceRotation), Space.Self);
        }
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void FixedCharacterPosition()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
    }

    private void MoveForward()
    {
        if (isDeath)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.Rotate(0, 0, 0, Space.Self);
            SFXAudio.PlayOneShot(SFXAudioClip[4]);
            Time.timeScale = 0;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, forwardSpeed);
        }
    }

    private void Tilting()
    {
        if(Input.acceleration.x == 0)
        {
            tiltDirection = Input.GetAxis("Horizontal");
        }
        else
        {
            tiltDirection = Input.acceleration.x;
        }

        tiltRotation = -tiltDirection * tiltSpeed * Time.deltaTime;
    }

    private void Unbalance()
    {
        if(transform.rotation.z < 0)
        {
            unbalanceDirection = -1;
        }
        else
        {
            unbalanceDirection = 1;
        }

        unbalanceRotation = unbalanceDirection * unbalanceSpeed * Time.deltaTime;
    }

    private void WindBlowEffect()
    {
        if(!isWindBlow)
        {
            windDirectionRand = Random.Range(0, 2);
        }
        
        if (windDirectionRand < 0.5)
        {
            windDirection = -1;
            BGMAudio.panStereo = -0.5f;
        }
        else
        {
            windDirection = 1;
            BGMAudio.panStereo = 0.5f;
        }

        windRotation = windDirection * windSpeed * Time.deltaTime;
    }
    private void WindBlowTimer()
    {
        if(windCountdownTimer <= 0)
        {
            StartCoroutine(WindBlow());
        }
        else if (windCountdownTimer <= 0.1)
        {
            BGMAudio.clip = BGMAudioClip[1];
            BGMAudio.Play();

            windCountdownTimer -= Time.deltaTime;
        }
        else if(windCountdownTimer <= 3)
        {
            warningSign.SetActive(true);
            windCountdownTimer -= Time.deltaTime;

            if(!isWarning)
            {
                SFXAudio.PlayOneShot(SFXAudioClip[5]);
                isWarning = true;
            }
        }
        else
        {
            windCountdownTimer -= Time.deltaTime;
            isWarning = false;
        }
    }
    private IEnumerator WindBlow()
    {
        WindBlowEffect();

        isWindBlow = true;

        yield return new WaitForSeconds(WindDuration);

        isWindBlow = false;

        windRotation = 0;

        BGMAudio.panStereo = 0;
        BGMAudio.clip = BGMAudioClip[0];
        BGMAudio.Play();

        warningSign.SetActive(false);
        
        windCountdownTimer = windOriTimer;
    }

    private void Dead()
    {
        if (transform.rotation.z >= 0.35f || transform.rotation.z <= -0.35f)
        {
            isDeath = true;
        }
        else
        {
            isDeath = false;
        }
    }

    private void powerupDuration()
    {
        if (PU1_Upgrade_State == 0)
        {
            PU1Duration = 5;
        }
        else if (PU1_Upgrade_State == 1)
        {
            PU1Duration = 10;
        }
        else
        {
            PU1Duration = 15;
        }


        if (PU2_Upgrade_State == 0)
        {
            PU2Duration = 5;
        }
        else if (PU2_Upgrade_State == 1)
        {
            PU2Duration = 10;
        }
        else
        {
            PU2Duration = 15;
        }
    }

    private void outfitEquipped()
    {
        if (Outfit1_isEquiped == 1)
        {
            isOutfit1 = true;
        }
        else
        {
            isOutfit1 = false;
        }

        if (Outfit2_isEquiped == 1)
        {
            isOutfit2 = true;
        }
        else
        {
            isOutfit2 = false;
        }

        if (Outfit3_isEquiped == 1)
        {
            isOutfit3 = true;
        }
        else
        {
            isOutfit3 = false;
        }
    }

    private void PowerUpEffect()
    {
        if (isPU1)
        {
            unbalanceSpeed = oriUnbalanceSpeed / 2 ;
        }
        else
        {
            unbalanceSpeed = oriUnbalanceSpeed;
        }
    }

    private void OutfitEffect()
    {
        if(isOutfit1 || isOutfit3)
        {
            unbalanceSpeed = oriUnbalanceSpeed;
        }

        if (isOutfit2)
        {
            unbalanceSpeed = oriUnbalanceSpeed / 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            coinNum++;
            SFXAudio.PlayOneShot(SFXAudioClip[0]);
        }

        if(other.CompareTag("PowerUp1"))
        {
            isPU1 = true;
            StartCoroutine(PU1Timer());
        }

        if(other.CompareTag("PowerUp2"))
        {
            isPU2 = true;
            StartCoroutine(PU2Timer());
        }

        if(other.CompareTag("Obstacle"))
        {
            if(isOutfit3)
            {
                isOutfit3 = false;
            }
            else if(isPU2)
            {
                isPU2 = false;
            }
            else
            {
                SFXAudio.PlayOneShot(SFXAudioClip[3]);
                isDeath = true;
                Time.timeScale = 0;
            }
        }
    }
    IEnumerator PU1Timer()
    {
        SFXAudio.PlayOneShot(SFXAudioClip[1]);
        yield return new WaitForSeconds(PU1Duration);
        SFXAudio.PlayOneShot(SFXAudioClip[2]);
        isPU1 = false;
    }
    IEnumerator PU2Timer()
    {
        SFXAudio.PlayOneShot(SFXAudioClip[1]);
        yield return new WaitForSeconds(PU2Duration);
        SFXAudio.PlayOneShot(SFXAudioClip[2]);
        isPU2 = false;
    }
}
