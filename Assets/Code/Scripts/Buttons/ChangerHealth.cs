using UnityEngine;
using UnityEngine.UI;

public abstract class ChangerHealth : MonoBehaviour
{
    [SerializeField] private Button _healthChangedButton;
    [SerializeField] private Unit _unit;

    protected Unit Unit => _unit;

    private void OnEnable()
    {
        _healthChangedButton.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        _healthChangedButton.onClick.RemoveListener(ChangeHealth);
    }

    protected abstract void ChangeHealth();
}