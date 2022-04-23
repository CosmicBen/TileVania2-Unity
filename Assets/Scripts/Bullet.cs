using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;

    private Rigidbody2D myRigidbody;
    private PlayerMovement player;
    private float xSpeed;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = Mathf.Sign(player.transform.localScale.x) * bulletSpeed;

        transform.localScale = new Vector2(Mathf.Sign(player.transform.localScale.x) * transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
