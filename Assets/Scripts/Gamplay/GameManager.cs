using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    private UIManager ui;
    public static Action onGameOver;
    private Player player;
    private FenceGenerator fenceGenerator;
    
    public static bool isPlaying;
    public static int score;
    public static Action<int> OnScore;
    private void Awake(){
        ui = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
        fenceGenerator = FindObjectOfType<FenceGenerator>();
    }
    
    private void Start(){
        Player.OnFenceHit += OnFenceHit;
        Player.OnGroundHit += OnGroundHit;
        Player.OnFencePassed += OnFencePassed;

    }
    
    
    private void OnFenceHit(){
        isPlaying = false;
    }
    
    
    private void OnGroundHit()
    {
        isPlaying = false;

        ui.PushScreen(ScreenType.GameOver);
        player.Disable();
    }
   
   
   private void OnFencePassed(){
        score++;
    } 
    
    
    public void StartGame(){
        score = 0;
        isPlaying = true;
        player.Enable();
    }
    

    

   

    private void Update(){
       if(!isPlaying){
           return;
       }
       fenceGenerator.GenerateFences();
    }

    
    
}