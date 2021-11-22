using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType  //enums are outside the class (ooo spooky)
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;   //what kind of pickup is it?
    public int value;         //how many of said pickup?

    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private bool bobbingUp;

    void Start()
    {
        startPos = transform.position;
    }
    void OnTriggerEnter(Collider other)  //if you collide with the player, give its script your info
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

    //a switch is a chonky if/else statement. infinite if's and elses
            switch(type)  
            {                      //\/\/\/ using a colon means "wait, I'm not done!" a semi colon signifies the end of a block
                case PickupType.Health:                  //if it's health, do this
                    player.GiveHealth(value);
                    break; //gotta break after each case to escape

                case PickupType.Ammo:                    //if it's ammo, do this
                    player.GiveAmmo(value);
                    break;
            }

            Destroy(gameObject);  //no infinite pickups for you
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = bobbingUp == true ? new Vector3(0,bobHeight / 2,0) : new Vector3(0, -bobHeight /2,0);
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
