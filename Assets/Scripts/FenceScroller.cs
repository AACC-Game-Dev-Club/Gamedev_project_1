using UnityEngine;

public class FenceScroller : MonoBehaviour
{
    private FencePool pool; 
    private Fence fence; 

    public float speed = 2.0f;  

    private void Awake(){
        pool = FindObjectOfType<FencePool>();
        fence  = GetComponent<Fence>();
    }

    void Update()
    {
        float cameraLeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0 ,0.5f, Camera.main.nearClipPlane)).x;
        transform.Translate(speed * Time.deltaTime * Vector2.left);
        if(transform.position.x + transform.localScale.x < cameraLeftEdge ){
            pool.Return(fence);
        }
    }

}
