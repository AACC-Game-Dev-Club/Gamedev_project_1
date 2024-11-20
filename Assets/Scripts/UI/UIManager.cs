using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 public enum ScreenType{
        MainMenu,
        GameOver,
        Game
    }

/// <summary>
/// This class manages the UI screens in the game
/// </summary>
public class UIManager : MonoBehaviour
{
   
    private Screen currentScreen;
    private readonly Stack<Screen> screens = new(); 

    [SerializeField]private readonly Screen initialScreen;
    
    private void Start(){
        if(initialScreen != null){

            PushScreen(initialScreen);
        }

        foreach(Transform child in transform){
            if(child.TryGetComponent<Screen>(out var screen))
            {
                screens.Push(screen);
            }
        }
    }
    
    /// <summary>
    /// Resets the UI by clearing the stack and pushing the initial screen
    /// </summary>
    public void Reset(){
        initialScreen.Enter();
    }

    /// <summary>
    /// Pushes a screen to the stack and activates it given the screen type
    /// </summary>
    /// <param name="screen"></param>
    public void PushScreen(ScreenType screen){
        Screen screenToPush = screens.FirstOrDefault(s => s.ScreenName == screen);
        screenToPush.Enter();
    }

   


    /// <summary>
    /// Pops a screen from the stack and deactivates it given the screen type
    /// </summary>
    public void PopScreen(ScreenType screen){
        Screen screenToPop = screens.FirstOrDefault(s => s.ScreenName == screen);
        screenToPop.Exit();
    }

    public void PushScreen(Screen screen){
        currentScreen = screen;

        screen.Enter();
    }

   


    /// <summary>
    /// Pops a screen from the stack and deactivates it
    /// </summary>
    /// <param name="screen"></param>
    public void PopScreen(Screen screen){
        if(!screen){
            currentScreen.Exit();
        }
        screen.Exit();
    }

}