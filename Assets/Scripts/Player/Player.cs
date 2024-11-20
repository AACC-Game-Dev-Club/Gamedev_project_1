using System;
using UnityEngine;

/// <summary>
/// This class represents the player in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public static Action OnFenceHit;
    public static Action<int> OnScore;
    public static Action OnGroundHit;

    private PlayerVisualController visualController;
    private Rigidbody2D rb2d;

    public LayerMask fenceLayerMask; // Set this in the Inspector
    private int score;
    private bool hasPassedFence;
    public static Action OnFencePassed;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        hasPassedFence = false;
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
        hasPassedFence = false;
        transform.position = Vector3.zero;
        visualController.StartAnimation();
        DisablePhysics();
    }

    public void EnablePhysics() {
        rb2d.simulated = true;
    }

    public void DisablePhysics() {
        rb2d.simulated = false;
    }

    private void FixedUpdate() {
        CheckFencePassed();
    }

    private void CheckFencePassed() {
        // Raycast directly below the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, fenceLayerMask);

        if (hit.collider != null) {
            Debug.Log($"Hit Object: {hit.collider.gameObject.name}, Tag: {hit.collider.gameObject.tag}");
            Debug.DrawRay(transform.position, Vector2.down * hit.distance, Color.green);
        } else {
            Debug.Log("No object detected.");
            Debug.DrawRay(transform.position, Vector2.down * 5f, Color.red);
        }

        bool didScore = false;
        bool fenceFound = hit.collider != null && hit.collider.CompareTag("Fence");
        //If fence found and we didnt score yet
        if (fenceFound && !didScore) {
            didScore = true;
            OnFencePassed?.Invoke();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Fence")) {
            OnFenceHit?.Invoke();
            visualController.StopAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            OnGroundHit?.Invoke();
            visualController.StopAnimation();
        }
    }
}
