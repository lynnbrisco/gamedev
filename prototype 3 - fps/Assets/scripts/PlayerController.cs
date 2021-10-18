using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
//allows weapon script to be referenced
    private Weapon weapon;
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
        weapon = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))   //jump when spacebar is pressed
            Jump();
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; //input values
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; //get mouse input to look around
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); //restrain vertical rotation of camera

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0); //apply code to unity camera
        transform.eulerAngles += Vector3.up * y;
    }
}
