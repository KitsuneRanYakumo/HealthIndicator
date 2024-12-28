using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minAmount = 0;
    [SerializeField] private float _maxAmount = 100;

    public event Action<float, float> AmountChanged;
    public event Action AmountWasted;

    public float Amount { get; private set; }

    public float MaxAmount => _maxAmount;

    public float MinAmount => _minAmount;

    public void Initialize()
    {
        Amount = _maxAmount;
        AmountChanged?.Invoke(Amount, MaxAmount);
    }

    public void TakeTreatment(float amount)
    {
        Amount += amount;
        AmountChanged?.Invoke(Amount, MaxAmount);
    }

    public void TakeDamage(float damage)
    {
        Amount -= damage;
        AmountChanged?.Invoke(Amount, MaxAmount);

        if (Amount <= 0)
            AmountWasted?.Invoke();
    }
}