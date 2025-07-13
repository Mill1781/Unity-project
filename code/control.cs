using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject toprightlimitob;
    public GameObject bottomleftlimitob;

    private Vector3 toprightlimit;
    private Vector3 bottomleftlimit;
    public int playhealth = 200;
    public float movespeed;
    public float supertime;
    float speedX, speedY;
    private bool waiting = false;
    Rigidbody2D ob;
    Transform tf;
    void Start()
    {
        tf = GetComponent<Transform>();
        ob = GetComponent<Rigidbody2D>();
        toprightlimit = toprightlimitob.transform.position;
        bottomleftlimit = bottomleftlimitob.transform.position;
    }

    void Update()
    {
        float directiony = Input.GetAxisRaw("Vertical");
        float directionx = Input.GetAxisRaw("Horizontal");
        speedY = directiony * movespeed;
        speedX = directionx * movespeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedY *= 2;
            speedX *= 2;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speedX /= 2;
            speedY /= 2;

        }
        if ((tf.position.x <= bottomleftlimit.x && directionx == -1) || (tf.position.x >= toprightlimit.x && directionx == 1))
        {
            speedX = 0;
        }
        if ((tf.position.y >= toprightlimit.y && directiony == 1) || (tf.position.y <= bottomleftlimit.y && directiony == -1))
        {
            speedY = 0;
        }

        ob.velocity = new Vector2(speedX, speedY);
        


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && !waiting)
        {
            playhealth -= 40;
            waiting = true;
            StartCoroutine(invincibletime());
        }
        else if (playhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator invincibletime()
    {
        yield return new WaitForSeconds(supertime);
        waiting = false;
    }

}
