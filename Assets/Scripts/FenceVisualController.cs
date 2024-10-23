using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceVisualController : MonoBehaviour
{
    [SerializeField]private SpriteRenderer bodySprite;
    private SpriteRenderer fenceSprite;

    private Fence fence;

    private void Awake()
    {
        fence = GetComponent<Fence>();
        fenceSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    { 
        SetUp();
    }

    private void SetUp(){
        // Set the scale of the fence's body based on its height and direction
        Vector2 scale = new(bodySprite.transform.localScale.x, fence.Height * fence.Direction.y);
        bodySprite.transform.localScale = scale;

        // Reposition the fence to start at its bottom edge
        fence.transform.position = new Vector2(fence.transform.position.x, fence.transform.position.y + scale.y / 2);

        // Flip the fence vertically if it is facing down
        if (fence.Direction.y < 0) {
            fenceSprite.flipY = true;
        }
    }
   
   

}
