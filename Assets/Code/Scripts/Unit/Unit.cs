using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public event Action<float> DamageReceived;
    public event Action<float> TreatmentReceived;

    public Health Health { get; private set; }

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

    public void TakeDamage(float amount)
    {
        Health.TakeDamage(amount);
        DamageReceived?.Invoke(amount);
    }

    public void Heal(float amount)
    {
        Health.TakeTreatment(amount);
        TreatmentReceived?.Invoke(amount);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}