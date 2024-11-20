using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FenceGenerator : MonoBehaviour
{

    [SerializeField] private Pool<Fence> pool; 

    
    /// <summary>
    /// The minimum vertical gap between the top and bottom fences
    /// </summary>
    [SerializeField] private float minGapY;
    /// <summary>
    /// The maximum vertical gap between the two fences
    /// </summary>
    [SerializeField] private float maxGapY;

 /// <summary>
    /// The minimum horizontal gap between fences
    /// </summary>
    [SerializeField] private float minGapX;
    /// <summary>
    /// The maximum horizontal gap between fences
    /// </summary>
    [SerializeField] private float maxGapX;

    /// <summary>
    /// The current fence that is being generated. Does not include both fences. 
    /// It is used to determine when to generate a new fence
    /// </summary>
    private Fence currentFence;
   
    /// <summary>
    /// The minimum height of the fence
    /// </summary>
    [SerializeField] private float minHeight;
    private readonly List<Fence> fences = new List<Fence>();

    private void Start()
    {
        FenceScroller.OnFenceOutOfView += OnFenceOutOfView;
    }
    /// <summary>
    /// Generates two fences with randomized vertical and horizontal gap between each generation
    /// </summary>
    private void GenerateFence(){

        float verticalGap = Random.Range(minGapY, maxGapY);
        float horizontalGap = Random.Range(minGapX, maxGapX); 

        Vector3 spawnPositionTop = GetSpawnPosition(verticalGap, horizontalGap, Vector2Int.up);
        
        Vector3 spawnPositionBottom = GetSpawnPosition(verticalGap, horizontalGap, Vector2Int.down);

        SpawnFence(spawnPositionTop,verticalGap, Vector2Int.up);
        SpawnFence(spawnPositionBottom,verticalGap,Vector2Int.down);

        
        

        

    }

    public void GenerateFences()
    {    
        // If there are no fences, generate a new fence
        if(currentFence == null){
            GenerateFence();    
        }
        // If the current fence has passed the generator, generate a new fence
        else if(currentFence.transform.position.x <= transform.position.x){
          GenerateFence();
        }        
    }

    private void OnFenceOutOfView(Fence fence){
        fences.Remove(fence);
        pool.Return(fence);
    }
     
   
    /// <summary>
    /// Spawns a fence with the given spawn position and direction
    /// </summary>
    /// <param name="height"></param>
    /// <param name="direction"></param>
    /// <summary>
    /// Spawns a fence with the given spawn position, vertical gap, and direction
    /// </summary>
    /// <param name="spawnPosition">The position where the fence will be spawned</param>
    /// <param name="verticalGap">The vertical gap between the fences</param>
    /// <param name="verticalDirection">The direction the fence is pointing towards</param>
    private void SpawnFence(Vector3 spawnPosition, float verticalGap, Vector2Int verticalDirection){
        
        Fence fence = pool.Get();
        if(fence == null){
            return;
        }
        fences.Add(fence);

        fence.Init(verticalDirection, verticalGap);
        fence.transform.position = spawnPosition;
        currentFence = fence;      
    }
    
    /// <summary>
    /// Determines the fence's spawn position based on the direction it is pointing (up or down)
    /// </summary>
    /// <param name="direction">The direction the fence is pointing towards. (up means the fence is pointing down 
    /// and down means the fence is pointing up</param>
    /// <returns>The spawn position</returns>
    private Vector3 GetSpawnPosition(float verticalGap, float horizontalGap, Vector2Int verticalDirection)
    {
        Vector3 spawnPosition = Vector3.zero;
       
        // Apply the randomized vertical gap
        spawnPosition.y = transform.position.y + verticalGap /2 * verticalDirection.y;
        
        // Apply the randomized horizontal gap
        spawnPosition.x = transform.position.x + horizontalGap; 

        return spawnPosition;
    }

    public void Reset(){
        pool.FillPool();
        fences.Clear();
    }
}
