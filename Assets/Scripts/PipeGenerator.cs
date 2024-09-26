using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float heightRange = 2.0f;
    [SerializeField] private float maxTime = 3.0f;
    [SerializeField] private float lifeSpan = 3.0f;
    private float timer;

   
    private void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        //Spawn a pipe every X seconds
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }

    private void SpawnPipe()
    {
        //Randomize spawn position within a range and then create a pipe that will destroy itself automatically
        //Once again, matching Vector sizes. Quaternion.identity -- no rotation.
        Vector3 spawnPosition = (transform.position + new Vector3(0, Random.Range(-heightRange, heightRange)));
        GameObject tempPipe = Instantiate(pipe, spawnPosition, Quaternion.identity);
        
        //Must use tempPipe or Unity thinks you're trying to delete a prefab
        Destroy(tempPipe, lifeSpan);
    }
}
