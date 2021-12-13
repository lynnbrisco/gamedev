using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //change rb velocity for floaty jump
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 4.5f, rb.velocity.y);

        //jump if spacebar is hit
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
    }
}
