using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scorecounter;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        scorecounter.text = score.ToString("000000");
    }
}
