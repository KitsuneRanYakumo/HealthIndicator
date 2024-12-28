using UnityEngine;

public class HealButton : ChangerHealth
{
    [SerializeField] private float _treatment;

    protected override void ChangeHealth()
    {
        Unit.Heal(_treatment);
    }
}