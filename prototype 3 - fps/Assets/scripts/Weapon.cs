using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }
        return false;
    }

    public void Shoot()
    {
        //adjust shoot time, decrease ammo when shot
        lastShootTime = Time.time;
        curAmmo --;

        //create the bullet
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.position;

        //speed of bullet
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
