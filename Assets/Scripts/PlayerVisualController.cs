using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlappyAnimation
{
    public Sprite[] sprites;
    public float frameRate = 0.05f;
}

public class PlayerVisualController : MonoBehaviour
{
    [SerializeField] private FlappyAnimation flappyAnimation;
    private SpriteRenderer spriteRenderer;
    private bool isAnimating = true;
    private int spriteCount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteCount = flappyAnimation.sprites.Length; // Cache the sprite array length
    }

    private void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        int index = 0;
        
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
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(Animate());
        }
    }
}
