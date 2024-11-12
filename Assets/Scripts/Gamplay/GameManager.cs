using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    public static Action onGameOver;
    private Player player;
    private FenceGenerator fenceGenerator;
    
    public static bool isPlaying;
    public static int score;

    private void Awake(){
        uiManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
        fenceGenerator = FindObjectOfType<FenceGenerator>();
    }
    
    private void Start(){
        Player.OnFenceHit += OnGameOver;
        Player.OnGroundHit += OnGroundHit;

    }

    private void OnGroundHit()
    {
       

        uiManager.PushScreen(ScreenType.GameOver);
        OnGameOver();

    }

    public void StartGame(){
        score = 0;
        isPlaying = true;
        player.EnablePhysics();
    }

    private void OnGameOver(){
        isPlaying = false;
        
    }

    
    
}