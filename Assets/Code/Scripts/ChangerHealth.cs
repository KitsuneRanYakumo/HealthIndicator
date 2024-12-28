using UnityEngine;
using UnityEngine.UI;

public class ChangerHealth : MonoBehaviour
{
    [SerializeField] private Button _healthChangedButton;
    [SerializeField] private TypeChangedHealth _typeChangedHealth;
    [SerializeField] private float _amount;
    [SerializeField] private Unit _unit;

    private void OnEnable()
    {
        _healthChangedButton.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        _healthChangedButton.onClick.RemoveListener(ChangeHealth);
    }

    private void ChangeHealth()
    {
        switch (_typeChangedHealth)
        {
            case TypeChangedHealth.Treatment:
                Heal(_amount);
                break;

            case TypeChangedHealth.Damage:
                Attack(_amount);
                break;
        }
    }

    private void Attack(float amount)
    {
        _unit.TakeDamage(amount);
    }

    private void Heal(float amount)
    {
        _unit.Heal(amount);
    }
}