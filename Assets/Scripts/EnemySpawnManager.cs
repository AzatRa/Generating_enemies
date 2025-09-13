using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners = new();
    [SerializeField] private Pool _pool;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private float _spawnInterval = 2f;
    
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Enemy enemy = _pool.Get();
            _colorChanger.Change(enemy);
            Spawner spawner = SpawnerSelection();
            spawner.Spawn(enemy, spawner.transform.position);
            enemy.CollidedWithWall += OnCapsuleCollision;
            _timer = 0f;
        }
    }

    private void OnCapsuleCollision(Enemy enemy)
    {
        enemy.CollidedWithWall -= OnCapsuleCollision;
        _pool.Release(enemy);
    }

    private Spawner SpawnerSelection()
    {
        return _spawners[Random.Range(0, _spawners.Count)]; ;
    }
}
