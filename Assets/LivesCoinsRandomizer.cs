using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCoinsRandomizer : MonoBehaviour {

    //Spawn this object
    public GameObject spawnObject;


    [Header("Time spawn")]
    public float maxTime = 5;
    public float minTime = 2;

    [Header("X-range spawn")]

    public float minX = -8f;
    public float maxX = 84f;

    [Header("Z-range spawn")]

    public float minZ = -45f;
    public float maxZ = 13f;


    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;

        StartCoroutine(SpawnTime());
    }

    IEnumerator SpawnTime()
    {
        GameObject prefab = Instantiate(spawnObject, new Vector3(Random.Range(minX, maxX), 3.1f, Random.Range(minZ, maxZ)), spawnObject.transform.rotation);
        yield return new WaitForSeconds(5f);
        Destroy(prefab);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
