using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
   private float height;
   private Vector2 direction;

   public void Init(float height, Vector2 direction){
        this.height = height;
        this.direction = direction;
        InitVisuals();
   }

    private void InitVisuals(){
        SetHeight();
        SetPosition();
    }
    private void SetHeight(){
       
        transform.localScale = new Vector2(transform.localScale.x, height * direction.y);

    }
    private void SetPosition(){
       
        // transform.position = new Vector2(transform.position.x, (transform.position.y + height));
        
    }
}
