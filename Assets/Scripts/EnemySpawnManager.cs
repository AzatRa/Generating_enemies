using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners = new();
    [SerializeField] private float _spawnInterval = 2f;
    
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Spawner spawner = SpawnerSelection();
            spawner.Spawn(spawner.transform.position);
            _timer = 0f;
        }
    }

    private Spawner SpawnerSelection()
    {
        return _spawners[Random.Range(0, _spawners.Count)]; ;
    }
}
