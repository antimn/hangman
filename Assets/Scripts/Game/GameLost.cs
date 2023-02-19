using TMPro;
using UnityEngine;

namespace HangmanClass.Scripts
{
    public class GameLost : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loseText;

        public void LoseShowText()
        {
            print("You Lost!");
            if (_loseText != null) _loseText.text = "You Lost!";
        }
    }
}