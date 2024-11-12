using TMPro;
using UnityEngine;
public class GameScreen : Screen{
   [SerializeField]private TextMeshProUGUI scoreText;

   private void Start(){
       Player.OnScore += (score) =>{
              scoreText.text = score.ToString();
       };
   }


}