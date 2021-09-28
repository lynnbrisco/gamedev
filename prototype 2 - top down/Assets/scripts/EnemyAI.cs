using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //various definitions
public GameObject bullet;
public Transform player;
public float moveSpeed;
private Rigidbody2D rb;
private Vector2 movement;

//called before first frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

//called once per frame
    void Update()
    {
    //player follow
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

//called at a fixed rate per frame
    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

//defined by ^^^
    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position * (direction * moveSpeed * Time.deltaTime));
    }
//triggered by a collision
    void OnTriggerEnter2D(Collider2D other)
    {
    //bullet destroys enemy
        if(other.gameObject.CompareTag("bullet"));
        {
            Destroy(gameObject);
        }
    }
}