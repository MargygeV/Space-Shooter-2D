using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class Unit: MonoBehaviour
{
    protected float _health;
    protected float _currentHealth;
    protected float _damage;

    protected Animator _animator;
    protected CapsuleCollider2D _collider2D;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<CapsuleCollider2D>();
    }

    public void ApplyDamage(float damage)
    {
        if(_currentHealth - damage > 0)
        {
            _currentHealth -= damage;

            WhenTakingDamage();
        }
        else
        {
            _currentHealth -= damage - (damage - _currentHealth);

            WhenDied();            
        }
    }

    protected virtual void WhenTakingDamage()
    {
        _animator.SetTrigger("Damaged");
    }

    protected virtual void WhenDied()
    {
        StartCoroutine(Die());
    }

    protected IEnumerator Die()
    {
        _animator.SetTrigger("Die");
        _collider2D.enabled = false;

        yield return new WaitForSeconds(0.8f);

        gameObject.SetActive(false);
        _collider2D.enabled = true;  

        EndingDieCoroutine();      
    }

    protected virtual void EndingDieCoroutine()
    {
        StopCoroutine(Die());
    }
}
