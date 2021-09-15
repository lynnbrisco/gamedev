using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed;
    // Left and Right Input
    public float hInput;
    //forward and back Input
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        // Getting button press values fr horizontal and vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //makes vehicle go left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
        //makes vehicle go forward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
