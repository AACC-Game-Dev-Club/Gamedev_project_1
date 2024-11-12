using UnityEngine;

/// <summary>
/// The FenceScroller class is responsible for moving the fence object to the left at a constant speed.
/// When the fence moves out of the camera's view, it triggers an event to notify that the fence should be destroyed.
/// </summary>
public class FenceScroller : MonoBehaviour
{
    /// <summary>
    /// The speed at which the fence moves to the left.
    /// </summary>
    public float speed = 5.0f;

    /// <summary>
    /// Event triggered when the fence should be disabled because it has left the screen.
    /// </summary>
    public static event System.Action<Fence> OnFenceShouldBeDisabled;

    private Fence fence;

   
    private void Awake()
    {
        fence = GetComponent<Fence>();
    }

   
    void Update()
    {
        if(!GameManager.isPlaying){
            return;
        }
        /* Moves the fence to the left and checks if it has moved out of the camera's view.
         * If the fence has moved out of view, triggers the OnFenceShouldBeDestroyed event.
         */ 
        float cameraLeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, Camera.main.nearClipPlane)).x;
        transform.Translate(speed * Time.deltaTime * Vector2.left);
        if (transform.position.x + transform.localScale.x < cameraLeftEdge)
        {
            OnFenceShouldBeDisabled?.Invoke(fence);
        }
    }
}
