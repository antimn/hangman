using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HangmanClass.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _enterWord;
        [SerializeField] private TextMeshProUGUI _hpField;
        [SerializeField] private HangmanController _hangmanController;
        [SerializeField] private DescriptionController _descriptionController;
        [SerializeField] private List<WordModel> _words;
        [SerializeField] private int hp = 6;

        private List<char> guessedLetters = new List<char>();
        private List<char> wrongTriedLetter = new List<char>();
        private WordModel wordToGuess;
        private KeyCode lastKeyPressed;

        private void Start()
        {
            var randomIndex = Random.Range(0, _words.Count);
            wordToGuess = _words[randomIndex];
            _descriptionController.SetDescription(wordToGuess.Description);
        }

        void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (e.keyCode != KeyCode.None && lastKeyPressed != e.keyCode)
                {
                    ProcessKey(e.keyCode);
                    lastKeyPressed = e.keyCode;
                }
            }
        }


        private void ProcessKey(KeyCode key)
        {
            print("Key Pressed: " + key);

            // Получаем нажатую букву в верхнем регистре
            char pressedKeyChar = char.ToUpper((char)key);

            // Проверяем, содержит ли загаданное слово нажатую букву
            bool wordContainsPressedKey = wordToGuess.Word.ToUpper().Contains(pressedKeyChar);

            // Проверяем, была ли нажатая буква уже угадана
            bool letterWasGuessed = guessedLetters.Contains(pressedKeyChar);

            // Если буква не угадана ранее и не содержится в загаданном слове, добавляем ее в список неверно угаданных букв
            if (!letterWasGuessed && !wordContainsPressedKey)
            {
                wrongTriedLetter.Add(pressedKeyChar);
                hp -= 1;
                if (_hpField != null) _hpField.text = "-1 HP/ " + hp;

                print("Wrong letter! Hp left = " + hp);
                print("Word  = " + wordToGuess);
                _hangmanController.HangmanDrawer(hp);

                if (hp <= 0)
                {
                    GameLost gameLost = gameObject.GetComponent<GameLost>();
                    gameLost.LoseShowText();
                }
            }

            // Если буква не угадана ранее и содержится в загаданном слове, добавляем ее в список угаданных букв
            if (!letterWasGuessed && wordContainsPressedKey)
            {
                guessedLetters.Add(pressedKeyChar);
            }

            // Формируем строку для вывода
            string stringToPrint = "";
            for (int i = 0; i < wordToGuess.Word.Length; i++)
            {
                char letterInWord = char.ToUpper(wordToGuess.Word[i]);

                if (guessedLetters.Contains(letterInWord))
                {
                    stringToPrint += letterInWord;
                }
                else
                {
                    stringToPrint += "_";
                }
            }

            if (wordToGuess.Word.ToUpper() == stringToPrint.ToUpper())
            {
                GameWin gameWin = gameObject.GetComponent<GameWin>();
                gameWin.WinShowText();
            }

            print(stringToPrint);
            if (_enterWord != null) _enterWord.text = stringToPrint;
        }
    }
}
