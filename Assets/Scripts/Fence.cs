using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
   public float Height {get; private set;}
   public Vector2 Direction {get; private set;}

   public void Init(float height, Vector2 direction){
        Height = height;
        Direction = direction;
   }

   
   
}
