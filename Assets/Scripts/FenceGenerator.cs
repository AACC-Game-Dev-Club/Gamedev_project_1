using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FenceGenerator : MonoBehaviour
{

    
    private float elapsedTime = 0.0f;
    [SerializeField] private Fence fence;
    
    /// <summary>
    /// The minimum vertical gap between the top and bottom fences
    /// </summary>
    [SerializeField]private float minGap;
    /// <summary>
    /// The maximum vertical gap between the two fences
    /// </summary>
    [SerializeField]private float maxGap;

    
    public List<Fence> Fences { get; private set; } = new();
    
    /// <summary>
    /// The maximum amount of time it will take for another fence to spawn
    /// </summary>
    [SerializeField]private float maxTime = 4;

    /// <summary>
    /// The minimum amount of time it will take for another fence to spawn
    /// </summary>
    [SerializeField]private float minTime = 2;
    
    /// <summary>
    /// The minimum height of the fence
    /// </summary>
    [SerializeField]private float minHeight;
    
   
    /// <summary>
    /// Generates a fence with randomized gap and time between each generation
    /// </summary>
    private void GenerateFences(){
        elapsedTime += Time.deltaTime;

        if (elapsedTime > maxTime)
        {     
            maxTime = Random.Range(minTime, maxTime);      
            
            //random gap size between min and mx gap values
            float cameraHeight = 2f * Camera.main.orthographicSize;

            //random gap size between the min and max gap values
            float gapY = Random.Range(minGap, maxGap);

            //Calculate the remaining height for the top and bottom fences
            float remainingHeight = cameraHeight - gapY;

            //Generates random heights for the bottom and top fences
            float bottomHeight = Random.Range(minHeight, remainingHeight);
            float topHeight = remainingHeight - bottomHeight;

            SpawnFence(bottomHeight, Vector2Int.up);
            SpawnFence(topHeight, Vector2Int.down);
            elapsedTime = 0.0f;
        }

        

    }

    private void Update()
    {
        GenerateFences();
        
    }

   
    /// <summary>
    /// Determines the fence's spawn position based on the direction it is pointing (up or down)
    /// </summary>
    /// <param name="direction">The direction the fence is pointing towards. (up means the fence is pointing up from the bottom 
    /// and down means the fence is pointing down from the top</param>
    /// <returns>The spawn position</returns>
    private Vector2 DecideSpawnPosition(Vector2Int direction)
    {
        Vector3 spawnPosition = Vector3.zero;

        if (direction == Vector2Int.up)
        {
            // Get the bottom of the camera's viewport
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.nearClipPlane));
        }
        else if (direction == Vector2Int.down)
        {
            // Get the top of the camera's viewport
            spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, Camera.main.nearClipPlane));
        }
        spawnPosition.x = transform.position.x;


        
        return spawnPosition;
    }

    /// <summary>
    /// Spawns a fence with the given height and direction
    /// </summary>
    /// <param name="height"></param>
    /// <param name="direction"></param>
    private void SpawnFence(float height, Vector2Int direction){
        
        Vector2 spawnPosition = DecideSpawnPosition(direction);   
        Fence fence = Instantiate(this.fence, spawnPosition, Quaternion.identity);
        fence.Init(height, direction);
        Fences.Add(fence);
    }
}
