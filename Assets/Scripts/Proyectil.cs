using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 1.0f;
    public Animator anim;
    public bool functional = true;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.shotnum++;
        functional = true;
        anim.SetBool("explodin", false);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        //if (!functional)
        //{
        //    speed = 0f;
        //    anim.SetBool("explodin", true);
        //    Destroy(gameObject, 0.5f);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched " + collision.tag);
        if (functional)
        {
            if (collision.tag == "Alien1" || collision.tag == "Alien2" || collision.tag == "Alien3")
            {
            
                if (collision.GetComponent<AlienMover>().alive == true)
                {
                    explode("alien");
                    collision.GetComponent<AlienMover>().die();
                }
            }
            else if (collision.tag == "Ceiling")
            {
                explode("ceiling");
            }
        }
    }
    void explode(string explosiontype)
    {
        functional = false;
        player.shotnum--;
        if (explosiontype == "alien")
        {
            speed = 0f;
            // anim.SetBool("explodin", true);
            Destroy(gameObject);
        }
        if (explosiontype == "barrier")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            Destroy(gameObject, 0.5f);
        }
        if (explosiontype == "ceiling")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            Destroy(gameObject, 0.5f);
        }
    }

}
