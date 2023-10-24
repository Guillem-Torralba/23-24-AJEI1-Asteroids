using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    public int startlives;
    public int lives;
    public TextMeshProUGUI livescounter;
    string countlives;
    void Start()
    {
        lives = startlives;    
    }

    // Update is called once per frame
    public void Losealife()
    {
        lives--;
        countlives = null;

        for (int i = 0; i < lives; i++)
        {
            countlives += "<sprite=23>";

        }
        livescounter.text = countlives;

    }
    void Update()
    {
    }
}
