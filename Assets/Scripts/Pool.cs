using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _poolCapasity = 50;
    [SerializeField] private int _poolMaxSize = 100;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize);
    }

    public Enemy Get()
    {
        return _pool.Get();
    }

    public void Release(Enemy obj)
    {
        _pool.Release(obj);
    }
}
