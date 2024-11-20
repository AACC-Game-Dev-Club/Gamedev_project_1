using TMPro;
using UnityEngine;
public class GameScreen : Screen{
   [SerializeField]private TextMeshProUGUI scoreText;

   private void Update(){
    scoreText.text = GameManager.score.ToString();
   }


}