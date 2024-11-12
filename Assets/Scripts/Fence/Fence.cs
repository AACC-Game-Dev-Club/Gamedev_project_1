
using UnityEngine;

/// <summary>
/// Represents a fence with a specific direction and gap.
/// </summary>
public class Fence :MonoBehaviour
{
   /// <summary>
   /// Gets the direction of the fence. The direction is whether the fence is on the bottom or top of the screen.
   /// </summary>
   public Vector2 Direction { get; private set; }

   /// <summary>
   /// Gets the gap of the fence.
   /// </summary>
   public float Gap { get; private set; }

   /// <summary>
   /// Initializes the fence with the specified direction and gap.
   /// </summary>
   /// <param name="direction">The direction of the fence.</param>
   /// <param name="gap">The gap of the fence.</param>
   public void Init(Vector2 direction, float gap)
   {
      Direction = direction;
      Gap = gap;
      InitVisuals();
   }
   
   /// <summary>
   /// Initializes the visuals of the fence.
   /// </summary>
   private void InitVisuals()
   {
      FenceVisualController visualController = new FenceVisualController();
      visualController.Init(this);
   }
}

   
   
   

