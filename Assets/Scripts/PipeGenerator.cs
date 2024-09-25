using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{

    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;
    private float elapsedTime = 0.0f;
    [SerializeField] private GameObject pipe;
    public List<GameObject> pipes { get; private set; } = new();
    private float maxTime = 2;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > maxTime)
        {
            GameObject topPipe = Instantiate(pipe, top.position, Quaternion.identity);
            GameObject bottomPipe = Instantiate(pipe, bottom.position, Quaternion.identity);
            pipes.Add(topPipe);
            pipes.Add(bottomPipe);
            elapsedTime = 0.0f;
        }

        
    }
}
