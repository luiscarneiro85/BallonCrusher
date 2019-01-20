using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

    public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CloseIntro()
    {
        text.SetActive(false);

    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
