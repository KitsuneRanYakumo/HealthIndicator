using UnityEngine;
using UnityEngine.UI;

public class ViewHealthBar : ViewHealth
{
    [SerializeField] private Slider _slider;

    protected override void DisplayState(float amount, float maxAmount)
    {
        _slider.maxValue = maxAmount;
        _slider.value = amount;
    }
}