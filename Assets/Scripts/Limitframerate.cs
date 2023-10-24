using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitframerate : MonoBehaviour
{
    // Start is called before the first frame update
    public int framerate;
    void Start()
    {
        Application.targetFrameRate = framerate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
