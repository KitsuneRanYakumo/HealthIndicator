using TMPro;
using UnityEngine;

public class ViewHealthText : ViewHealth
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    protected override void DisplayState(float amount, float maxAmount)
    {
        _textMeshPro.text = $"{amount}/{maxAmount}";
    }
}