using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMover : MonoBehaviour
{
    public Animator anim;
    public int Scoreworth = 10;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Animationspeed", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
