using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    GameObject st;
	// Use this for initialization
	void Start () {
        st = GameObject.Find("Settings");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().volume = st.GetComponent<Settings>().bgmVolume;
	}
}
