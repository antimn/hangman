using TMPro;
using UnityEngine;

namespace HangmanClass.Scripts
{
    public class GameWin : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winText;

        public void WinShowText()
        {
            print("You win!");
            if (_winText != null) _winText.text = "You win!";
        }
    }
}