using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner1;
    [SerializeField] private Spawner _spawner2;
    [SerializeField] private Spawner _spawner3;
    [SerializeField] private Spawner _spawner4;
    [SerializeField] private Pool _pool;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private float _spawnInterval = 2f;
    
    private float _timer;
    private List<Spawner> _spawners = new List<Spawner>();

    private void Start()
    {
        _spawners.AddRange(new Spawner[4] { _spawner1, _spawner2, _spawner3, _spawner4 });
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Capsule capsule = _pool.Get();
            _colorChanger.Change(capsule);
            Spawner spawner = SpawnerSelection();
            spawner.Spawn(capsule, spawner.transform.position);
            capsule.OnWallCollision += OnCapsuleCollision;
            _timer = 0f;
        }
    }

    private void OnCapsuleCollision(Capsule capsule)
    {
        capsule.OnWallCollision -= OnCapsuleCollision;
        _pool.Release(capsule);
    }

    private Spawner SpawnerSelection()
    {
        return _spawners[Random.Range(0, _spawners.Count)]; ;
    }
}
