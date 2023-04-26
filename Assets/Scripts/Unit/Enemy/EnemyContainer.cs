using UnityEngine;

public class EnemyContainer : ObjectPool
{
    private EnemyAttributes _attributes;

    public void GetEnemy(Transform spawnPoint)
    {
        InitSpawnpoint(spawnPoint);
        _pool.Get();
    }

    public void Init(EnemyAttributes attributes)
    {
        _attributes = attributes;
    }

    protected override void InitInstance(GameObject newObject)
    {
        newObject.GetComponent<Enemy>().Init(_attributes);
    }
}
