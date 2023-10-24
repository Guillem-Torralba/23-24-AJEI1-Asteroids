using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        originalspeed = speed;
        basemaxshots = maxshots;
        vulnerable = true;
    }
    float originalspeed = 0f;
    public float speed = 1.0f;
    float horizontal;
    public GameObject proyectil;
    public Animator anim;
    public int shotnum;
    public int maxshots;
    int basemaxshots;
    public Lives lives;
    public bool vulnerable;


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
        if (transform.position.x < -8.4 )
        {
            transform.position = new Vector3(-8.4f, transform.position.y, 0);
        }
        if (transform.position.x > 8.4)
        {
            transform.position = new Vector3(8.4f, transform.position.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (vulnerable)
        {
            if (collision.tag == "Alienshot" && collision.GetComponent<Alienshot>().functional == true) 
            {
                StartCoroutine(die(true, collision));
            }
            if (collision.tag == "Alien1" || collision.tag == "Alien2" || collision.tag == "Alien3")
            {
                StartCoroutine(die());

            }
        }
    }
    void Shoot()
    {
        GameObject shot = Instantiate(proyectil, transform.position, Quaternion.identity);
        shot.GetComponent<Proyectil>().player = this;
    }
    public IEnumerator die(bool gotshot = false, Collider2D collision = null)
    {
        speed = 0f;
        vulnerable = false;
        anim.SetBool("Dying" , true);
        maxshots = 0;
        if(gotshot)
        {
            collision.GetComponent<Alienshot>().explode("player");
        }
        lives.Losealife();
        yield return new WaitForSeconds(1);
        if (lives.lives > 0)
        {
            Respawn();
        }
        else
        {
            Destroy(gameObject);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
    public void Respawn()
    {
        anim.SetBool("Dying", false);
        transform.position = new Vector3(0, transform.position.y, 0);
        speed = originalspeed;
        maxshots = basemaxshots;
        vulnerable = true;
    }
}
