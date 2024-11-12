using UnityEngine;


/// <summary>
/// This class represents a UI screen in the game
/// </summary>
public class Screen : MonoBehaviour{

    [SerializeField] private ScreenType screenName;
    public ScreenType ScreenName => screenName;
    /// <summary>
    /// Activates the screen
    /// </summary>
    public void Enter(){
        gameObject.SetActive(true);
    }
    /// <summary>
    /// Deactivates the screen
    /// </summary>
    public void Exit(){
        gameObject.SetActive(false);
    }
}