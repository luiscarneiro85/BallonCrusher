using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    public GameObject settingsPanel;
    public GameObject sliderBgm;
    public GameObject sliderEffects;
    public GameObject noBgm;
    public GameObject noEffects;
    GameObject gm;
    public float bgmVolume;
    public float effectsVolume;
    bool bgmActive = true;
    bool effectsActive = true;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Manager");
        noBgm.SetActive(false);
        noEffects.SetActive(false);
        settingsPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if(bgmActive) bgmVolume = sliderBgm.GetComponent<Slider>().value;
        if(effectsActive) effectsVolume = sliderEffects.GetComponent<Slider>().value;

        if(bgmVolume != 0)
        {
            noBgm.SetActive(false);
        }
        else
        {
            noBgm.SetActive(true);
        }

        if (effectsVolume != 0)
        {
            noEffects.SetActive(false);
        }
        else
        {
            noEffects.SetActive(true);
        }

    }

    public void ShowPanel()
    {
        if (gm.GetComponent<GameManager>().gameState.Equals("play"))
        {
            settingsPanel.SetActive(true);
            gm.GetComponent<GameManager>().gameState = "pause";
        }
        else if (gm.GetComponent<GameManager>().gameState.Equals("pause"))
        {
            settingsPanel.SetActive(false);
            gm.GetComponent<GameManager>().gameState = "play";
        }

    }

    public void NoBgmSound()
    {
        if (bgmVolume != 0)
        {
            bgmVolume = 0;
            bgmActive = false;
        }
        else
        {
            bgmActive = true;
        }
    }

    public void NoEffectsSound()
    {
        if (effectsVolume != 0)
        {
            effectsVolume = 0;
            effectsActive = false;
        }
        else
        {
            effectsActive = true;
        }
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Menu");
    }

}
