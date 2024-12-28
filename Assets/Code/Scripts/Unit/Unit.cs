using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public Health Health { get; private set; }

    public event Action<float> DamageReceived;
    public event Action<float> TreatmentReceived;

    private void OnEnable()
    {
        Health.AmountWasted += Destroy;
    }

    private void OnDisable()
    {
        Health.AmountWasted -= Destroy;
    }

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void Start()
    {
        Health.Initialize();
    }

    public void TakeDamage(float amount)
    {
        DamageReceived?.Invoke(amount);
    }

    public void Heal(float amount)
    {
        TreatmentReceived?.Invoke(amount);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}