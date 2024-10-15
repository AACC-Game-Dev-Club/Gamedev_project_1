using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsScroll;
    

    // This function will be called when the "Play" button is clicked
    public void OnPlayButtonClicked()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Logic to start the game goes here
        Debug.Log("Play button clicked!");
        SceneManager.LoadScene("Flappy Bird");
    }

    // This function will be called when the "Credits" button is clicked
    public void OnCreditsButtonClicked()
    {
        mainMenu.SetActive(false);  // Disable the Main Menu
        creditsScroll.SetActive(true);  // Enable the Credits Scroll
    }

    // This function will be called when the "Back" button is clicked
    public void OnBackButtonClicked()
    {
        creditsScroll.SetActive(false);  // Disable the Credits Scroll
        mainMenu.SetActive(true);  // Enable the Main Menu
    }
}