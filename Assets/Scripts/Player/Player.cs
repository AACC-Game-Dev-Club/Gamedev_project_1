using System;
using UnityEngine;

/// <summary>
/// This class represents the player in the game
/// </summary>
public class Player : MonoBehaviour
{
    private PlayerVisualController visualController;
    private Rigidbody2D rb2d;

    [SerializeField]private LayerMask fenceLayerMask;
    
    public static event Action OnFenceHit;

    public static event Action OnFencePassed;

    public static event Action OnGroundHit;

    private bool fencePassed = false;


    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Init();

    }
     public void Init() {
        transform.position = Vector3.zero;
        InitVisuals();
        Disable();



    }
    private void InitVisuals() {
        visualController = new PlayerVisualController();
        visualController.Init(this);
        visualController.StartAnimation();

    }
   
    public void Enable() {
        rb2d.simulated = true;
        visualController.StartAnimation();

    }

    public void Disable() {
        rb2d.velocity = Vector2.zero;
        rb2d.simulated = false;

    }
    
    
   

    private void FixedUpdate() {
        if(!GameManager.isPlaying){
            return;
        }
        CheckFencePassed();
    }

    private void CheckFencePassed() {
        // Raycast directly below the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(-0.5f, 0) , Vector2.down, Mathf.Infinity, fenceLayerMask);

        
        // Check if the raycast hit a fence
        bool fenceFound = hit.collider != null && hit.collider.CompareTag("Fence");
        
        //If fence found below the player and we didnt score yet
        if (fenceFound && !fencePassed) {
            
            //We scored!
            fencePassed = true;
            OnFencePassed?.Invoke();
        } 
        //If we didnt hit a fence, reset the didScore flag
        if(!fenceFound){
            
            fencePassed = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Fence")) {
            OnFenceHit?.Invoke();
            visualController.StopAnimation();

        }
        if (collider.gameObject.CompareTag("Ground")) {
            OnGroundHit?.Invoke();
            visualController.StopAnimation();

        }
    }

   
}
