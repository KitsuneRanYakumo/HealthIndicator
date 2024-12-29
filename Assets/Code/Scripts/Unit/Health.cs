using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minAmount = 0;
    [SerializeField] private float _maxAmount = 100;

    private float _amount;

    public event Action<float, float> AmountChanged;
    public event Action AmountWasted;

    public void Initialize()
    {
        _amount = _maxAmount;
        AmountChanged?.Invoke(_amount, _maxAmount);
    }

    public void TryTakeTreatment(float treatment)
    {
        if (treatment <= 0)
            return;

        treatment = Mathf.Min(treatment, _maxAmount - _amount);
        _amount += treatment;
        AmountChanged?.Invoke(_amount, _maxAmount);
    }

    public void TryTakeDamage(float damage)
    {
        if (damage <= 0)
            return;

        damage = Mathf.Min(damage, _amount - _minAmount);
        _amount -= damage;
        AmountChanged?.Invoke(_amount, _maxAmount);

        if (_amount <= 0)
            AmountWasted?.Invoke();
    }
}