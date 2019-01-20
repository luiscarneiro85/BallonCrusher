using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseApp()
    {
        Application.Quit();
    }

    public void PlayTheGame()
    {
        SceneManager.LoadScene("play");
    }

}
