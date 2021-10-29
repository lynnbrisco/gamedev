using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable time
    [Header("Stats")]   //organizes the interface
    public int curHP, maxHP, ScoreToGive;

    [Header("Movement")]
    public float moveSpeed, attackRange, yPathOffest;

    private List<Vector3> path;
    
    private Weapon weapon;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameobject;
    }

    void UpdatePath()
    {
        NavMeshPath navMeshPath = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed *Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
