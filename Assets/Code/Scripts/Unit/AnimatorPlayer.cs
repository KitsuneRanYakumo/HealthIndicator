using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private readonly int _damageTrigger = Animator.StringToHash("DamageReceived");
    private readonly int _treatmentTrigger = Animator.StringToHash("TreatmentReceived");

    private Animator _animator;

    private void OnEnable()
    {
        _unit.DamageReceived += SetDamageTrigger;
        _unit.TreatmentReceived += SetTreatmentTrigger;
    }

    private void OnDisable()
    {
        _unit.DamageReceived -= SetDamageTrigger;
        _unit.TreatmentReceived -= SetTreatmentTrigger;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void SetDamageTrigger(float damage)
    {
        _animator.SetTrigger(_damageTrigger);
    }

    private void SetTreatmentTrigger(float treatment)
    {
        _animator.SetTrigger(_treatmentTrigger);
    }
}