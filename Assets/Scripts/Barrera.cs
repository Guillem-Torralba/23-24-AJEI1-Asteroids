using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    // Start is called before the first frame update
    public int destructionstate;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Barrera", 0, (float)destructionstate/6 );
        if(destructionstate == 6)
        {
            Destroy(gameObject);
        }
    }
}
