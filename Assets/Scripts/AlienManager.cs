using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    public float startposX = 4;
    public List<AlienMover> AlienList;
    public Score score;
    public float animationspeed = 0.1f;
    public int aliencount;
    public bool switching = false;
    public float direction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //    for (int i = 0; i < 12; i++) {
        //        GameObject temp = Instantiate(Alien1, new Vector3(i * 1 + startposX, 4f, 0), Quaternion.identity, this.transform);
        //        AlienList.Add(temp.GetComponent<AlienMover>());
        //        temp.GetComponent<AlienMover>().Alienmanager = this;
        //        temp.GetComponent<AlienMover>().score = score;
        //        temp = Instantiate(Alien2, new Vector3(i * 1 + startposX, 3f, 0), Quaternion.identity, this.transform);
        //        AlienList.Add(temp.GetComponent<AlienMover>());
        //        temp.GetComponent<AlienMover>().Alienmanager = this;
        //        temp = Instantiate(Alien2, new Vector3(i * 1 + startposX, 2f, 0), Quaternion.identity, this.transform);
        //        AlienList.Add(temp.GetComponent<AlienMover>());
        //        temp.GetComponent<AlienMover>().Alienmanager = this;
        //        temp = Instantiate(Alien3, new Vector3(i * 1 + startposX, 1f, 0), Quaternion.identity, this.transform);
        //        AlienList.Add(temp.GetComponent<AlienMover>());
        //        temp.GetComponent<AlienMover>().Alienmanager = this;
        //        temp = Instantiate(Alien3, new Vector3(i * 1 + startposX, 0f, 0), Quaternion.identity, this.transform);
        //        AlienList.Add(temp.GetComponent<AlienMover>());
        //        temp.GetComponent<AlienMover>().Alienmanager = this;



        //    }
        SpawnRow(Alien1, 4f, 12);
        SpawnRow(Alien2, 3f, 12);
        SpawnRow(Alien2, 2f, 12);
        SpawnRow(Alien3, 1f, 12);
        SpawnRow(Alien3, 0f, 12);
    }

    // Update is called once per frame
    void Update()
    {
        aliencount = AlienList.Count;
        animationspeed = (1 / (float)aliencount)/1.5f;
    }
    void SpawnRow(GameObject alientype, float startposY, int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            GameObject temp = Instantiate(alientype, new Vector3(i * 1 + startposX, startposY, 0), Quaternion.identity, this.transform);
            AlienList.Add(temp.GetComponent<AlienMover>());
            temp.GetComponent<AlienMover>().Alienmanager = this;
            temp.GetComponent<AlienMover>().score = score;
        }
    }
    void GoDown(float downamount)
    {
        direction = -direction;

    }
}
