using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 15.0f;

    private float hInput;
    private float vInput;

    public float xRange = 8f;
    public float yRange = 6f;

    public GameObject bullet;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
    //input definition
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

    //player movement
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnspeed * hInput * Time.deltaTime);

    //player boundaries and walls
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > yRange)
        {
            transform.position = new Vector3(yRange, transform.position.x, transform.position.z);
        }
        if(transform.position.x < -yRange)
        {
            transform.position = new Vector3(-yRange, transform.position.x, transform.position.z);
        }

    //shooting the projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }}   
