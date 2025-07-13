using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 100;
    public float speed = 5f;
    public float stoptime = 2f;
    public float accelerationtime = 2f;
    private float timepassed = 0f;
    private bool isStop = false;
    public float pausetime = 0.1f;
    public float existancetime = 3f;
    int count = 0;
    void Start()
    {
        rb.velocity = new Vector2(0f, speed);
        
    }

    void Update()
    {
        if (!isStop && count != 1)
        {
            timepassed += Time.deltaTime;
            float speedrate = 1 - ((timepassed * timepassed) / stoptime);
            speedrate = Mathf.Clamp01(speedrate);
            rb.velocity = rb.velocity * speedrate;

            if (timepassed >= stoptime)
            {
                rb.velocity = Vector2.zero;
                isStop = true;
                StartCoroutine(RestartMovementAfterDelay());

            }
        }
        if(count == 1)
        {
            Destroy(gameObject, existancetime);
        }
    }
    IEnumerator RestartMovementAfterDelay()
    {
        // 等待指定的停頓時間
        yield return new WaitForSeconds(pausetime);


        float accelerationTimePassed = 0f;


        while (accelerationTimePassed < accelerationtime)
        {
            accelerationTimePassed += Time.deltaTime;
            float accelerationrate = Mathf.Clamp01(accelerationTimePassed / accelerationtime);


            rb.velocity = new Vector2(0f, speed * accelerationrate);
            yield return null;
        }
        rb.velocity = new Vector2(0f, speed);
        isStop = false;
        timepassed = 0f;
        count++;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }


}
