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
