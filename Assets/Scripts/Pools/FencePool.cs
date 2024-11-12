using UnityEngine;

// The FencePool class inherits from the Pool class to create a pool of Fence objects
public class FencePool : Pool<Fence>
{
    [SerializeField]private Fence prefab;
    public override Fence Prefab => prefab;
    public override string Name => "Fence";


}