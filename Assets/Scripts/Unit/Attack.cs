using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Attack : ObjectPool
{
    [SerializeField] private BulletAttributes _attributes;
    [SerializeField] private float _fireRate = 1f;

    private UnitAttributes _playerAttributes;

    private void Start()
    {
        StartCoroutine(PlayAttack());
    }

    public void Init(UnitAttributes playerAttributes)
    {
        _playerAttributes = playerAttributes;
    }

    private IEnumerator PlayAttack()
    {
        while(true)
        {
            _pool.Get();
            yield return new WaitForSeconds(_fireRate);
        }
    }

    protected override void InitInstance(GameObject newObject)
    {
        if(newObject.TryGetComponent<Bullet>(out Bullet bullet))
            bullet.Init(_attributes);
    }

    protected override void WhenGetObjectPool(GameObject currentObject)
    {
        if(currentObject.TryGetComponent<Bullet>(out Bullet bullet))
            bullet.CalculateDamage(_playerAttributes.Damage);
    }
}
