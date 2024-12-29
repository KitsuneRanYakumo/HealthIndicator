using UnityEngine;

public class DamageButton : ChangerHealth
{
    [SerializeField] private float _damage;

    protected override void ChangeHealth()
    {
        Unit.TryTakeDamage(_damage);
    }
}