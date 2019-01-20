using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float speed;
    public int hp;
    public int score;
    public bool ready = false;
    bool active = true;
    GameObject gm;
    GameObject mc;
    Animator anim;
    Vector2 movement;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        gm = GameObject.Find("Manager");
        mc = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 3)
        {
            GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
        }
        else if (hp == 2) 
        {
            GetComponent<SpriteRenderer>().color = new Color32(9, 255, 0, 255);
        }
        else if(hp == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }

        if (gm.GetComponent<GameManager>().gameState.Equals("play"))
        {
            //velocidade incrementa conforme level
            transform.Translate(Vector2.up * speed * gm.GetComponent<GameManager>().levelSpeed * Time.deltaTime);

            if (hp <= 0)
            {
                speed = 0;
                PopBalloon();
                
            }
        }

    }

    public void PopBalloon()
    {
        anim.SetTrigger("pop");
    }

    public void DestroyBalloon()
    {
        if (active)
        {
            gm.SendMessage("AddScore", score);
            active = false;
        }
        mc.SendMessage("PlayPopSound");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pop" && ready)
        {
            Destroy(collision.gameObject);
            hp -= 1;
        }
        if((collision.gameObject.tag == "wall" || collision.gameObject.tag == "brick") && ready)
        {
            hp = 0;
            if (active)
            {
                Instantiate(gm.GetComponent<GameManager>().brick, transform.position, transform.rotation);
                active = false;
            }

        }
    }

    void OnBecameInvisible()
    {
        // perde uma chance quando bala sai da tela
        if (active)
        {
            active = false;
        }

        DestroyBalloon();
    }

    void OnBecameVisible()
    {
        ready = true;
    }

    
}
