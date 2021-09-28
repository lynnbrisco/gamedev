using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
public GameObject bullet;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("bullet"));
        {
            Destroy(gameObject);
        }
    }
}