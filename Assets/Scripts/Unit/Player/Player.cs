using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : Unit
{
    public static event UnityAction<float> HealthChanged;
    public static event UnityAction Died;

    [SerializeField] private UnitAttributes _attributes;

    private Attack _attack;

    protected override void Awake()
    {
        base.Awake();
        _attack = GetComponent<Attack>();
    }

    private void Start()
    {
        Init();
        _attack.Init(_attributes);
        HealthChanged?.Invoke(_currentHealth);
    }

    private void Init()
    {
        _health = _attributes.Health;
        _damage = _attributes.Damage;
        _currentHealth = _health;
    }

    protected override void WhenTakingDamage()
    {
        base.WhenTakingDamage();
        HealthChanged?.Invoke(_currentHealth);
    }

    protected override void WhenDied()
    {
        HealthChanged?.Invoke(0f);
        base.WhenDied();
    }

    protected override void EndingDieCoroutine()
    {
        Died?.Invoke();
        base.EndingDieCoroutine();
    }
}