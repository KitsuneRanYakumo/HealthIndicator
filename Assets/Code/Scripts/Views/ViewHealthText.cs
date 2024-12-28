using TMPro;
using UnityEngine;

public class ViewHealthText : ViewHealth
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro.text = $"{Health.Amount}/{Health.MaxAmount}";
    }

    protected override void DisplayState(float amount, float maxAmount)
    {
        _textMeshPro.text = $"{amount}/{maxAmount}";
    }
}