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

        void Update()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode) && keyCode != lastKeyPressed)
                    {
                        ProcessKey(keyCode);
                        lastKeyPressed = keyCode;
                    }
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
    
    // Этот код содержит класс GameManager, который управляет игрой "Виселица".В нем есть несколько переменных, которые хранят
    // ссылки на объекты на сцене и на список слов, из которых выбирается загаданное слово.Также есть
    // переменные, которые хранят уже угаданные и неверно угаданные буквы, загаданное слово, количество жизней, и последнюю
    // нажатую клавишу.
    // Метод Start выбирает случайное слово из списка и показывает его описание.Метод Update проверяет, была ли
    // нажата клавиша на клавиатуре, и вызывает метод ProcessKey для обработки этой клавиши.Если клавиша была нажата
    // ранее, то она не обрабатывается повторно.Метод ProcessKey проверяет, содержится ли нажатая буква в загаданном
    // слове и была ли эта буква уже угадана.Если буква не была угадана ранее и не содержится в слове, она добавляется
    // в список неверно угаданных букв, количество жизней уменьшается, и вызывается метод для отрисовки виселицы.Если жизни
    // заканчиваются, вызывается метод GameLost.Если буква не была угадана ранее и содержится в слове, она добавляется
    // в список угаданных букв.Затем формируется строка, которая отображает угаданные буквы и пропуски, и выводится
    // на экран.Если слово угадано полностью, вызывается метод GameWin.