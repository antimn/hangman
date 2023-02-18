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