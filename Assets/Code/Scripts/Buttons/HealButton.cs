using UnityEngine;

public class HealButton : HealthChanger
{
    [SerializeField] private float _treatment;

    protected override void ChangeHealth()
    {
        Unit.Heal(_treatment);
    }
}