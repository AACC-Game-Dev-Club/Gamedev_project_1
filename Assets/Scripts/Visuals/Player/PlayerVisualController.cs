using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlappyAnimation
{
    public Sprite[] sprites;
    public float frameRate = 0.05f;
} 

public class PlayerVisualController
{
    private SpriteRenderer spriteRenderer;
    private bool isAnimating;
    private PlayerVisuals visuals; 

    private Player player;
    public void Init(Player player)
    {
        this.player = player;
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        visuals = player.GetComponent<PlayerVisuals>();

    }

   

    private IEnumerator Animate()
    {
        int index = 0;
        FlappyAnimation flappyAnimation = visuals.flappyAnimation;
        int spriteCount = flappyAnimation.sprites.Length; // Cache the sprite array length

        while (isAnimating)
        {
            // Cycle through sprites
            spriteRenderer.sprite = flappyAnimation.sprites[index];
            index = (index + 1) % spriteCount; // Loop back to the start when reaching the end

            // Wait based on frame rate
            yield return new WaitForSeconds(flappyAnimation.frameRate);
        }
    }

    public void StopAnimation()
    {
        isAnimating = false;
    }

    public void StartAnimation()
    {
        if(isAnimating){
            return;
        }
        isAnimating = true;
        player.StartCoroutine(Animate());
        
    }
}
