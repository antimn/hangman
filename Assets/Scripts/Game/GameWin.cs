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

            // Делаем кнопку рестарта активной
            restartButton.SetActive(true);

            // Отключаем возможность ввода слов
            // Этот код используется для отключения компонента GameManager в Unity.
            // Сначала он находит объект с компонентом GameManager с помощью метода FindObjectOfType().Затем он
            // устанавливает значение свойства enabled этого компонента в значение false, что приводит к
            // тому, что компонент больше не обрабатывает события в игр
            // Таким образом, если GameManager ранее управлял логикой игры, то после выполнения этого кода игрок не сможет
            // взаимодействовать с игрой, так как его логика более не обрабатывается.
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.enabled = false;
        }
    }
}