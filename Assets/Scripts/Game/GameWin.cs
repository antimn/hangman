using TMPro;
using UnityEngine;

namespace HangmanClass.Scripts
{
    public class GameWin : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winText;
        [SerializeField] private GameObject restartButton;

        public void WinShowText()
        {
            print("You win!");
            if (_winText != null) _winText.text = "You win!";
            
            restartButton.SetActive(true);
            
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.enabled = false;
        }
    }
}