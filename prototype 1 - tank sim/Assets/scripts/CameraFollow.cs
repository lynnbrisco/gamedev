using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tank;

    public Vector3 offset = new Vector3(25,25,-50);
    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + offset;
    }
}
