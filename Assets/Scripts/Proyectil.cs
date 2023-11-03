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
        // Debug.Log("touched " + collision.tag);
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
            else if (collision.tag == "UFO")
            {
                if (collision.GetComponent<UfoMover>().alive == true)
                {
                    explode("alien");
                    collision.GetComponent <UfoMover>().die();
                }
            }
            else if (collision.tag == "Ceiling")
            {
                explode("ceiling");
            }
            else if (collision.tag == "Alienshot")
            {
                if (collision.GetComponent<Alienshot>().functional == true)
                {
                    explode("alienshot", collision);
                }
            }
            else if (collision.tag == "Barrera")
            {
                explode("barrier", collision);
            }
        }
    }
    void explode(string explosiontype, Collider2D collision = null)
    {
        functional = false;
        player.shotnum--;
        if (explosiontype == "alien")
        {
            speed = 0f;
            // anim.SetBool("explodin", true);
            Destroy(gameObject);
        }
        else if (explosiontype == "barrier")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            collision.GetComponent<Barrera>().destructionstate++;
            Destroy(gameObject, 0.5f);
        }
        else if (explosiontype == "ceiling")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            Destroy(gameObject, 0.5f);
        }
        else if (explosiontype == "alienshot")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            Destroy(gameObject, 0.5f);
            collision.GetComponent<Alienshot>().explode("floor");
        }
        else
            Destroy(gameObject);
    }

}
