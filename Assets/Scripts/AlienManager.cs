using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    public GameObject UFO;
    public float startposX = 4;
    public List<AlienMover> AlienList;
    public Score score;
    public float animationspeed = 0.1f;
    public int aliencount;
    public bool switching = false;
    public float direction = 1f;
    public float basespeed = 1f;
    public float speed= 0f;
    public float shotperiod = 3;
    public float shottimer = 0f;
    public float ufoperiod = 10;
    public float ufotimer = 10;
    bool donespawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAliens());
        shottimer = 0;
        ufotimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        aliencount = AlienList.Count;
        if (aliencount >= 1 && donespawning)
        {
            animationspeed = (1 / (float)aliencount) / 1.5f;
            speed = basespeed * (1 / (float)aliencount);
            
            //alien shot timer
            if (shottimer >= shotperiod)
            {
                AlienList[Random.Range(0, AlienList.Count)].shoot(Random.Range(1, 4));
                shottimer -= shotperiod;
            }
            if (ufotimer >= ufoperiod)
            {
                CreateUfo();
                ufotimer -= ufoperiod;
            }
            shottimer += Time.deltaTime;
            ufotimer += Time.deltaTime;
        }
        if (donespawning && aliencount <= 0) // when all aliens are killed spawn new ones
        {
            transform.position = Vector3.zero;
            speed = 0;
            donespawning = false;
            
            StartCoroutine(SpawnAliens());

        }
        transform.position += new Vector3(speed * direction, 0, 0) * Time.deltaTime;
    }
    IEnumerator SpawnRow(GameObject alientype, float startposY, int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            GameObject temp = Instantiate(alientype, new Vector3(i * 1 + startposX, startposY, 0), Quaternion.identity, this.transform);
            AlienList.Add(temp.GetComponent<AlienMover>());
            temp.GetComponent<AlienMover>().Alienmanager = this;
            temp.GetComponent<AlienMover>().score = score;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator SpawnAliens()
    {
        StartCoroutine(SpawnRow(Alien3, 0f, 12));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnRow(Alien3, 1f, 12));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnRow(Alien2, 2f, 12));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnRow(Alien2, 3f, 12));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnRow(Alien1, 4f, 12));
        yield return new WaitForSeconds(2);
        donespawning = true;

    }
    public IEnumerator GoDown(float downamount)
    {
        switching = true;
        direction = -direction;
        transform.position += new Vector3(0, -downamount, 0);
        yield return new WaitForSeconds(0.1f);
        switching = false;
    }
    public void CreateUfo()
    {
        GameObject temp = Instantiate(UFO, new Vector3(10, 5, 0), Quaternion.identity);
        temp.GetComponent<UfoMover>().Alienmanager = this;
        temp.GetComponent<UfoMover>().score = score;
        Destroy(temp, 10f);
    }
}
