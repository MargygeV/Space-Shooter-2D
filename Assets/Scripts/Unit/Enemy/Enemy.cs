using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : Unit
{
    private SpriteRenderer _spriteRenderer;
    protected EnemyAttributes _attributes;

    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        SetValueCurrentHealth();
    }

    public void Init(EnemyAttributes attributes)
    {
        _attributes = attributes;

        _health = _attributes.Health;
        _damage = _attributes.Damage;

        SetValueCurrentHealth();

        _animator.runtimeAnimatorController = _attributes.AnimatorController;
        _spriteRenderer.sprite = _attributes.Sprite;
        _collider2D.size = _attributes.ColliderRadius;
        _collider2D.direction = _attributes.ColliderDirection;
    }

    private void SetValueCurrentHealth()
    {
        _currentHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            StartCoroutine(Die());
        }
    }  
}
