using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlappyAnimation{
    public Sprite[] sprites;

}
public class PlayerVisualController : MonoBehaviour
{
    
    [SerializeField]private FlappyAnimation flappyAnimation;
    private SpriteRenderer spriteRenderer;
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        StartCoroutine(Animate());
    }

    private IEnumerator Animate(){
        while(true){
            foreach(Sprite sprite in flappyAnimation.sprites){
            spriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
        }
       
    }
    


}
