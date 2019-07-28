using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour {
    
    private Transform target;
    private int wavepointIndex = 0;
    public GameObject waypointsGO;
    //private Waypoints waypoints;
    private Enemy enemy;
    private Transform[] Points;
    void Start()
    {
        Points = new Transform[waypointsGO.transform.childCount];
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = waypointsGO.transform.GetChild(i);
        }
        //waypoints = waypointsGO.GetComponent<Waypoints>();
        enemy = GetComponent<Enemy>();
        target = Points[0];//waypoints.
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //***********************
        transform.LookAt(target);
        //***********************
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Points.Length - 1)//waypoints.
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Points[wavepointIndex];//waypoints.
    }


    void EndPath()
    {
        if (PlayerStats.Lives == 0)
        {
            PlayerStats.Lives = 0;
        }
        else
        {
            PlayerStats.Lives--;
        }
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    //*********
    /*void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }*/
    //*********
}
