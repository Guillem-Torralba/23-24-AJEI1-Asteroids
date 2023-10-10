using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    public float startposX = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++) {
            Instantiate(Alien1, new Vector3(i * 1 + startposX,4f,0), Quaternion.identity);
            Instantiate(Alien2, new Vector3(i * 1 + startposX, 3f, 0), Quaternion.identity);
            Instantiate(Alien2, new Vector3(i * 1 + startposX, 2f, 0), Quaternion.identity);
            Instantiate(Alien3, new Vector3(i * 1 + startposX, 1f, 0), Quaternion.identity);
            Instantiate(Alien3, new Vector3(i * 1 + startposX, 0f, 0), Quaternion.identity);


        }      
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
