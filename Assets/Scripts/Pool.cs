using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private Capsule _prefab;
    [SerializeField] private int _poolCapasity = 50;
    [SerializeField] private int _poolMaxSize = 100;

    private ObjectPool<Capsule> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Capsule>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize);
    }

    public Capsule Get()
    {
        return _pool.Get();
    }

    public void Release(Capsule obj)
    {
        _pool.Release(obj);
    }
}
