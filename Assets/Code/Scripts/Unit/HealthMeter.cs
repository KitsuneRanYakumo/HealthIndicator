using UnityEngine;

[RequireComponent(typeof(Unit))]
public class HealthMeter : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

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

    private void TryIncreaseHealth(float treatment)
    {
        if (treatment <= 0)
            return;

        treatment = Mathf.Min(treatment, _unit.Health.MaxAmount - _unit.Health.Amount);
        _unit.Health.TakeTreatment(treatment);
    }

    private void TryDecreaseHealth(float damage)
    {
        if (damage <= 0)
            return;

        damage = Mathf.Min(damage, _unit.Health.Amount - _unit.Health.MinAmount);
        _unit.Health.TakeDamage(damage);
    }
}