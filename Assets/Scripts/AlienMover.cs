using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMover : MonoBehaviour
{
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
    public void die()
    {
        alive = false;
        score.score += Scoreworth;
        transform.parent = null;
        Alienmanager.AlienList.Remove(this);

        anim.SetBool("Exploding", true);
        
        Destroy(gameObject, 0.5f); 
    }
}
