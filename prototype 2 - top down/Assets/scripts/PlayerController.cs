using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 15.0f;

    private float hInput;
    private float vInput;

    // Update is called once per frame
    void Update()
    {
    //input definition
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

    //player movement
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnspeed * hInput * Time.deltaTime);
    }
}    
