using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Pool _pool;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    public void Spawn(Enemy enemy, Vector3 position)
    {
        float rotationAngle = 360f;

        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, rotationAngle), 0);
        enemy.gameObject.SetActive(true);
    }
}
