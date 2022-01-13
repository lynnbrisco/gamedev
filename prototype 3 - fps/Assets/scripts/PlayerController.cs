using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("stats")]
    public int curHP;
    public int maxHP;
    public int curAmmo;
    public int maxAmmo;

//movement
    [Header("movement")]
    public float moveSpeed; //speed
    public float jumpForce; //how high they jump
//camera
    [Header("camera")]
    public float lookSensitivity; //allows sensitivity controls
    public float maxLookX;        //lowest down you can look
    public float minLookX;        //highest up you can look
    private float rotX;           //current x rotation

//components
    private Camera cam;       //defines needed variables/grabs other scripts
    private Rigidbody rb;
    private Weapon weapon;

    void Awake() //awake is called when you press play
    {
        //grab and define variables first
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(000);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gamePaused == true)
            return;

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

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    void Die()
    {
        GameManager.instance.LoseGame();
    }

    public void GiveHealth(int amountToGive)  //health pickup gives hp
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP); //give health within a range (clamp acts as a restriction between two values, in this case it is the least and most hp possible)
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo(int amountToGive) //can use same variable as givehealth bc it's attached to separate functions
    {
        weapon.curAmmo = Mathf.Clamp(curAmmo + amountToGive, 0, weapon.maxAmmo); //give ammo within a certain range
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}
