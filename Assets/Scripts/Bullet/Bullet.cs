using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    private float _damageMultiplier;
    private float _speed;
    private float _totalDamage;

    private BulletAttributes _attributes;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveToForward();
    }

    public void Init(BulletAttributes attributes)
    {
        _attributes = attributes;

        _spriteRenderer.sprite = _attributes.Sprite;
        _damageMultiplier = _attributes.DamageMultiplier;
        _speed = _attributes.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(_totalDamage);
            gameObject.SetActive(false);
        }
    }

    private void MoveToForward()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime);
    }

    public void CalculateDamage(float playerDamage)
    {
        _totalDamage = playerDamage * _damageMultiplier;
    }
}
