using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienshot : MonoBehaviour
{
    public float speed = 1f;
    public Animator anim;
    public bool functional = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed, 0)*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "floor")
        {
            explode("floor");
        }
        else if (collision.tag == "Barrera")
        {
            explode("barrier", collision);
        }
    }

    public void explode(string explosiontype, Collider2D collision = null)
    {
        functional = false;
        if (explosiontype == "player")
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
        else if (explosiontype == "floor")
        {
            speed = 0f;
            anim.SetBool("explodin", true);
            Destroy(gameObject, 0.5f);
        }
        else
            Destroy(gameObject);
    }
}
