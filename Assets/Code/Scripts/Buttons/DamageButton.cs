using UnityEngine;

public class DamageButton : HealthChanger
{
    [SerializeField] private float _damage;

    protected override void ChangeHealth()
    {
        Unit.TakeDamage(_damage);
    }
}