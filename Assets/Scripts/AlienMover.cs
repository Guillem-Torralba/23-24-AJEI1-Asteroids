using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMover : MonoBehaviour
{
    public GameObject alienshot1;
    public GameObject alienshot2;
    public GameObject alienshot3;
    public Rigidbody2D rb;
    public Animator anim;
    public int Scoreworth = 10;
    public bool alive = true;
    public AlienManager Alienmanager;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        anim.SetBool("Exploding", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Animationspeed", Alienmanager.animationspeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "wall") {
            if (!Alienmanager.switching) {
            
                StartCoroutine(Alienmanager.GoDown(0.5f));
            }
        }
    }
    public void die()
    {
        alive = false;
        score.score += Scoreworth;
        transform.parent = null;
        rb.velocity = Vector3.zero;
        Alienmanager.AlienList.Remove(this);

        anim.SetBool("Exploding", true);
        
        Destroy(gameObject, 0.5f); 
    }
    public void shoot(int type)
    {
        if (type==1)
            Instantiate(alienshot1, transform.position, Quaternion.identity );
        else if (type == 2)
            Instantiate(alienshot2, transform.position, Quaternion.identity);
        else
            Instantiate(alienshot3, transform.position, Quaternion.identity);
    }
}
