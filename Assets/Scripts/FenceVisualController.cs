using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceVisualController
{
    private SpriteRenderer fenceSprite;

    private Fence fence;
    private FenceVisuals visuals;

  
    
    public void Init(Fence fence){
        this.fence = fence;
        fenceSprite = fence.GetComponent<SpriteRenderer>();
        visuals = fence.GetComponent<FenceVisuals>();
        
        SetUp();
    }

    private void SetUp(){
        // Set the scale of the fence's body based on its height and direction
        Vector2 scale = new(visuals.fenceBody.transform.localScale.x, fence.Height * fence.Direction.y);
        visuals.fenceBody.transform.localScale = scale;

        // Reposition the fence to start at its bottom edge
        fence.transform.position = new Vector2(fence.transform.position.x, fence.transform.position.y + scale.y / 2);

        // Flip the fence vertically if it is facing down
        if (fence.Direction.y < 0) {
            fenceSprite.flipY = true;
        }
    }
   
   

}
