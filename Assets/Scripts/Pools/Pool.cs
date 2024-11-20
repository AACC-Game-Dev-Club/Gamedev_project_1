using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// This class represents a pool of objects
/// </summary>
public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    public int poolSize = 10; 
    public abstract T Prefab {get;}
    public abstract string Name {get;}

    public readonly Queue<T> pool = new();

    private void Awake()
    {
        FillPool();
    }
    private void EmptyPool()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
      
        pool.Clear();
    }
    public void FillPool()
    {
        // Empty the pool before filling it
        EmptyPool();
        for (int i = 0; i < poolSize; i++)
        {

            T obj = Instantiate(Prefab, transform);
            obj.gameObject.SetActive(false);
            obj.transform.parent = transform;   
            pool.Enqueue(obj);
        }
    }
    /// <summary>
    /// Gets an object from the pool
    /// </summary>
    /// <returns></returns>
    public T Get()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true); 
            return obj;
        }
        return default;
    }


    /// <summary>
    /// Returns an object to the pool
    /// </summary>
    
    public void Return(T obj)
    {
        obj.transform.position = Vector3.zero;
        obj.gameObject.SetActive(false);  
        pool.Enqueue(obj);   
    }

    
}
