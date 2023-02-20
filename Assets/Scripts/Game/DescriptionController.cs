using TMPro;
using UnityEngine;

public class DescriptionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionText;

    public void SetDescription(string description)
    {
        _descriptionText.text = description;
    }
}

// В скрипте есть одно поле:
// _descriptionText типа TextMeshProUGUI, которое используется для отображения текста в игре.В методе SetDescription
// передается строка description, которая задает текст для отображения.Этот метод присваивает заданный текст
// _descriptionText, чтобы отобразить его в игре.