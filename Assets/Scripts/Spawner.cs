using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private ColorChanger _colorChanger;

    private void Awake()
    {
        if (_pool == null)
            Debug.LogError($"{nameof(_pool)} не назначен в {gameObject.name}");
        if (_colorChanger == null)
            Debug.LogError($"{nameof(_colorChanger)} не назначен в {gameObject.name}");
    }

    public void Spawn(Vector3 position)
    {
        float rotationAngle = 360f;

        Enemy enemy = _pool.Get();
        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, rotationAngle), 0);
        _colorChanger.Change(enemy);
        enemy.gameObject.SetActive(true);
        enemy.CollidedWithWall += OnEnemyCollision;
    }

    private void OnEnemyCollision(Enemy enemy)
    {
        enemy.CollidedWithWall -= OnEnemyCollision;
        _pool.Release(enemy);
    }
}
