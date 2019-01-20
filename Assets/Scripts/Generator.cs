using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    GameObject gm;
    GameManager script;
    float timer = 0;
    public float sleep = 0;
    public bool ready = true;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Manager");
        script = gm.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void MakeBalloon()
    {
        //seleciona qual balão vai ser gerado
        int balloon = Mathf.RoundToInt(Random.Range(0, script.listOfBalloons.Count));
        Instantiate(script.listOfBalloons[balloon], transform.position, transform.rotation);
        StartCoroutine(SleepTime());
    }

    IEnumerator SleepTime()
    {
        ready = false;
        yield return new WaitForSeconds(sleep - gm.GetComponent<GameManager>().levelSleep);
        ready = true;
    }
}
