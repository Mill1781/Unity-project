using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public Rigidbody2D rb;
    public float existancetime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, existancetime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
