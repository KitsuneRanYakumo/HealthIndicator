using UnityEngine;

[RequireComponent(typeof(Unit))]
public class HealthMeter : MonoBehaviour
{
    private Unit _unit;

    private void OnEnable()
    {
        _unit.TreatmentReceived += TryIncreaseHealth;
        _unit.DamageReceived += TryDecreaseHealth;
    }

    private void OnDisable()
    {
        _unit.TreatmentReceived -= TryIncreaseHealth;
        _unit.DamageReceived -= TryDecreaseHealth;
    }

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void TryIncreaseHealth(float treatment)
    {
        _unit.Health.TakeTreatment(GetDeltaHealth(treatment, true));
    }

    private void TryDecreaseHealth(float damage)
    {
        _unit.Health.TakeDamage(GetDeltaHealth(damage, false));
    }

    private float GetDeltaHealth(float amount, bool isIncreased)
    {
        float target;
        float deltaHealth;

        if (amount <= 0)
            return 0;

        if (isIncreased)
            target = _unit.Health.MaxAmount;
        else
            target = _unit.Health.MinAmount;

        float summaryHealth = Mathf.MoveTowards(_unit.Health.Amount, target, amount);

        if (isIncreased)
            deltaHealth = summaryHealth - _unit.Health.Amount;
        else
            deltaHealth = _unit.Health.Amount - summaryHealth;

        return deltaHealth;
    }
}