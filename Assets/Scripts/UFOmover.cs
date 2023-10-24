using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMover : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public int Scoreworth = 10;
    public bool alive = true;
    public AlienManager Alienmanager;
    public Score score;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        anim.SetBool("Exploding", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void die()
    {
        alive = false;
        score.score += Scoreworth;
        speed = 0;
        rb.velocity = Vector3.zero;
        // Alienmanager.AlienList.Remove(this);

        anim.SetBool("Exploding", true);
        
        Destroy(gameObject, 0.5f); 
    }
}
