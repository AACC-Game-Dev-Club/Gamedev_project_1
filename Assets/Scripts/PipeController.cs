using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    [SerializeField] private float speed = 0.8f;
    private PipeGenerator pipeGenerator;
    // Start is called before the first frame update
    void Awake()
    {
        pipeGenerator = FindObjectOfType<PipeGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject pipe in pipeGenerator.pipes)
        {
            pipe.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

    }
}
