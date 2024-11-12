using System;
using UnityEngine;

/// <summary>
/// This class represents the player in the game
/// </summary>
public class Player : MonoBehaviour
{
    public static Action OnFenceHit;
    private PlayerVisualController visualController;
    private Rigidbody2D rb2d;
    private LayerMask layerMask;
    internal static Action<int> OnScore;
    private int score;

    public static Action OnGroundHit { get; internal set; }

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    private void Start() {
        InitVisuals();
        DisablePhysics();
    }

    private void InitVisuals() {
        visualController = new PlayerVisualController();
        visualController.Init(this);
        visualController.StartAnimation();

    }
    public void Reset() {
        score = 0;
        transform.position = Vector3.zero;
        visualController.StartAnimation();
        DisablePhysics();
        rb2d.simulated = false;


    }
    public void EnablePhysics() {
        rb2d.simulated = true;
    }

    public void DisablePhysics() {
        rb2d.simulated = false;
    }
    
    
   void FixedUpdate ()
    {
        // Does the ray intersect any objects excluding the player layer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.collider.gameObject.tag);

        }
        
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Fence"))
        { 
            Debug.DrawRay(transform.position, Vector2.down * hit.distance, Color.green); 
            Debug.Log("Did Hit"); 
            score++;
            OnScore?.Invoke(score);


        }
        else
        { 
            Debug.DrawRay(transform.position, Vector2.down * 1000, Color.red); 
            Debug.Log("Did not Hit"); 
        }
        
    }
   

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Fence")) {
            OnFenceHit?.Invoke();
            visualController.StopAnimation();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            OnGroundHit?.Invoke();
            visualController.StopAnimation();

        }
    }
    
   
    private void Die() {
        OnFenceHit?.Invoke();
    }
    
    

   

     
}
