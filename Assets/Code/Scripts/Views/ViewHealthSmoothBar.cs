using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViewHealthSmoothBar : ViewHealth
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _rateOfChange = 0.1f;
    [SerializeField] private float _timeOneTick = 0.1f;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private float _target;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeOneTick);
        _slider.value = Health.MaxAmount;
    }

    protected override void DisplayState(float amount, float maxAmount)
    {
        _slider.maxValue = maxAmount;
        _target = amount;
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(ChangeValueBar());
    }

    private IEnumerator ChangeValueBar()
    {
        while (_slider.value != _target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _target, _rateOfChange);
            yield return _wait;
        }
    }
}