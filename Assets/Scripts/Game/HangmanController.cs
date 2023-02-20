using System.Collections.Generic;
using UnityEngine;

namespace HangmanClass.Scripts
{
    public class HangmanController : MonoBehaviour
    {
        [SerializeField] List<SpriteRenderer> _hangmanBody;
        [SerializeField] List<Sprite> _hangmanSprites;

        public void HangmanDrawer(int hpLeft)
        {
            var index = 5 - hpLeft;
            _hangmanBody[index].sprite = _hangmanSprites[index];
        }
    }
}

    // Переменная _hangmanBody - это список спрайтов виселицы, а _hangmanSprites - список спрайтов, которые отображаются на
    // каждом шаге.
    // Метод HangmanDrawer отвечает за отрисовку текущего элемента виселицы в зависимости от количества
    // попыток, оставшихся у игрока.Он принимает на вход количество оставшихся попыток hpLeft и рассчитывает индекс
    // элемента виселицы для отображения.Затем метод изменяет спрайт элемента виселицы на соответствующий спрайт
    // из _hangmanSprites в списке _hangmanBody.Например, если у игрока осталось 5 попыток, то index будет равен 0, так
    // как отображается первый элемент виселицы.Затем метод изменит спрайт элемента _hangmanBody[0] на
    // соответствующий спрайт из _hangmanSprites[0].Таким образом, данный скрипт обновляет визуальное представление
    // виселицы на каждом шаге игры и отображает оставшиеся попытки игрока.