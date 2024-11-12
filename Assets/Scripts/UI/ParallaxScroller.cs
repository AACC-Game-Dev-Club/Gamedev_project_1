using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
  public float scrollSpeed;  // Speed of the scrolling effect
    private RectTransform rectTransform;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        // Move the background to the left based on the scroll speed
        transform.position += scrollSpeed * Time.deltaTime * Vector3.left;

        // Check if the background has moved off-screen and reposition it
        if (transform.position.x <= -rectTransform.rect.width)
        {
            // Move it to the right to create a looping effect
            float width = GetComponent<RectTransform>().rect.width;
            transform.position += new Vector3(width * 2, 0, 0);
        }
    }
}
