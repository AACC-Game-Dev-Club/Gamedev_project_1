using UnityEngine;

/// <summary>
/// The FenceVisualController class is responsible for setting up the visuals of the fence object.
/// It sets the scale and position of the fence's body based on its height and direction.
/// </summary>
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
        float offset =  0.5f;

        Vector2 scale = new(1, Camera.main.orthographicSize - (fence.Gap / 2));
        
        //Set the scale of the fence's body based on its height and direction
        visuals.fenceBody.transform.localScale = scale ;
           
        //Reposition the fence to start at its bottom edge
        visuals.fenceBody.transform.position = new Vector2(0, (fence.transform.position.y + (scale.y - 1) / 2 + offset) * fence.Direction.y);


        //Flip the fence vertically if it is facing down
        if (fence.Direction.y > 0) {
            fenceSprite.flipY = true;
        }
    }
   
   

}
