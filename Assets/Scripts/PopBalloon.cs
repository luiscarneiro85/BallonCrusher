using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBalloon : MonoBehaviour {

    public GameObject pop;
    Vector2 mousePosition;
    GameObject gm;
    GameObject st;
    int indice;
    AudioClip popSound;
    float volume;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Manager");
        st = GameObject.Find("Settings");
	}
	
	// Update is called once per frame
	void Update () {

        if (gm.GetComponent<GameManager>().gameState.Equals("play"))
        {
            // instancia objeto de colisao na posicao do toque na tela
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(pop, mousePosition, transform.rotation);
            }
        }

        volume = st.GetComponent<Settings>().effectsVolume;

	}

    public void PlayPopSound()
    {
        indice = Mathf.RoundToInt(Random.Range(0, gm.GetComponent<GameManager>().listOfPopSounds.Count));
        popSound = gm.GetComponent<GameManager>().listOfPopSounds[indice];
        GetComponent<AudioSource>().PlayOneShot(popSound,volume);
    }

}
