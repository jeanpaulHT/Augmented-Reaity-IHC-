using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombie;
    public Transform[] spawnPoints;

    private float timePassed;
    private float pauseSpawn;
    private float spawnSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseSpawn = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Time.realtimeSinceStartup;
        if (Math.Round(timePassed) % 10 == 0 && pauseSpawn < 0)
        {
            SpawnNewZombie();
            pauseSpawn = spawnSpeed;
        }
        pauseSpawn -= Time.deltaTime;
    }
    
    void SpawnNewZombie()
    {
        new WaitForSeconds(UnityEngine.Random.Range(0, 5));
        Instantiate(zombie, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)]);
        zombie.transform.localPosition = Vector3.zero;
    }
}
