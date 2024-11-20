using TMPro;
using UnityEngine;
public class GameScreen : Screen{
  private TextMeshProUGUI scoreText;
  private void Awake(){
    scoreText = GetComponentInChildren<TextMeshProUGUI>();
  }
  private void Update(){
      scoreText.text = GameManager.score.ToString();
  }
}