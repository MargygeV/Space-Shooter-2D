using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointsContainer;
    [SerializeField] private GameObject _enemyContainerPrefab;
    [SerializeField] private List<EnemyAttributes> _enemys;

    private int _lastSpawnPoint;
    private Transform[] _spawnPoints;
    private List<EnemyContainer> _enemyContainers = new List<EnemyContainer>();

    private void Start()
    {
        GetSpawnPointList();
        CreateEnemyContainers();
        StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    private void CreateEnemyContainers()
    {
        for(int i = 0; i < _enemys.Count; i++)
        {
            var newContainer = Instantiate(_enemyContainerPrefab, gameObject.transform);

            if(newContainer.TryGetComponent<EnemyContainer>(out EnemyContainer container))
            {
                _enemyContainers.Add(container);
                container.Init(_enemys[i]);
            }
        }
    }

    private void GetSpawnPointList()
    {
        var count = _spawnPointsContainer.childCount;
        _spawnPoints = new Transform[count];

        for(int i = 0; i < count; i++)
        {
            _spawnPoints[i] = _spawnPointsContainer.GetChild(i);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            var currentEnemy = Random.Range(0, _enemyContainers.Count);
            var currentSpawnPoint = Random.Range(0, _spawnPoints.Length);

            if(currentSpawnPoint == _lastSpawnPoint)
                continue;

            _lastSpawnPoint = currentSpawnPoint;
            _enemyContainers[currentEnemy].GetEnemy(_spawnPoints[currentSpawnPoint]);

            yield return new WaitForSeconds(1f);
        }
    }
}
