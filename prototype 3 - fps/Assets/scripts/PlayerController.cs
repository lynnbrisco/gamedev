using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
//movement
    public float moveSpeed; //speed
    public float jumpForce; //how high they jump
//camera
    public float lookSensitivity; //allows sensitivity controls
    public float maxLookX;        //lowest down you can look
    public float minLookX;        //highest up you can look
    private float rotX;           //current x rotation

//components
    private Camera cam;       //defines needed variables
    private Rigidbody rb;

    void Awake()
    {
        //grab and define variables first
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; //input values
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);    //maintain velocity on y, get inputs for x and z
    }
}
