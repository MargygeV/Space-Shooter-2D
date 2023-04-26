using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _prefab;

    protected ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(CreateObject,
            GetObject,
            collectionCheck: false,
            defaultCapacity: _capacity,
            maxSize: _capacity);
    }

    protected GameObject CreateObject()
    {
        var newObject = Instantiate(_prefab, _container);
        newObject.GetComponent<PoolInstance>().SetPool(_pool);

        InitInstance(newObject);

        return newObject;
    }

    private void GetObject(GameObject currentObject)
    {
        currentObject.transform.position = _spawnPoint.position;
        currentObject.transform.rotation = _spawnPoint.rotation;
        WhenGetObjectPool(currentObject);
        currentObject.SetActive(true);
    }

    protected void InitSpawnpoint(Transform point)
    {
        _spawnPoint = point;
    }

    protected virtual void InitInstance(GameObject newObject){}

    protected virtual void WhenGetObjectPool(GameObject currentObject){}
}
