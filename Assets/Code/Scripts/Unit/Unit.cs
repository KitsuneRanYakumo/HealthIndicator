using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public Health Health { get; private set; }

    public event Action<float> DamageReceived;
    public event Action<float> TreatmentReceived;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Health.AmountWasted += Destroy;
    }

    private void Start()
    {
        Health.Initialize();
    }

    private void OnDisable()
    {
        Health.AmountWasted -= Destroy;
    }

    public void TryTakeDamage(float amount)
    {
        Health.TryTakeDamage(amount);
        DamageReceived?.Invoke(amount);
    }

    public void TryHeal(float amount)
    {
        Health.TryTakeTreatment(amount);
        TreatmentReceived?.Invoke(amount);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}