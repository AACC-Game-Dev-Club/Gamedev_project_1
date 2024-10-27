using System.Collections.Generic;
using UnityEngine;

public class FencePool : MonoBehaviour
{
    public Fence fence; 
    public int poolSize = 10; 

    private readonly Queue<Fence> pool = new();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Fence fence = Instantiate(this.fence);
            fence.transform.parent = transform;
            fence.gameObject.SetActive(false); 
            pool.Enqueue(fence);
        }
    }

    public T Get<T>() where T : MonoBehaviour
    {
        if (pool.Count > 0)
        {
            Fence fence = pool.Dequeue();
            fence.gameObject.SetActive(true); 
            return fence as T;
        }
        return default;
    }

    public void Return(Fence fence)
    {
        fence.gameObject.SetActive(false);  
        pool.Enqueue(fence);   
    }
}
