using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 1.0f;
    float horizontal;
    public GameObject proyectil;
    public Animator anim;
    public int shotnum;
    public int maxshots;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        if (Input.GetButtonDown("Jump"))
        {
            if (shotnum < maxshots)
            {
                Shoot();
            }
            //else
            //{
            //    Debug.Log(shotnum.ToString());
            //}
        }
    }
    void Shoot()
    {
        GameObject shot = Instantiate(proyectil, transform.position, Quaternion.identity);
        shot.GetComponent<Proyectil>().player = this;
    }
}
