using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Pool _pool;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    public void Spawn(Capsule capsule, Vector3 position)
    {
        float rotationAngle = 360f;

        capsule.transform.position = position;
        capsule.transform.rotation = Quaternion.Euler(0, Random.Range(0, rotationAngle), 0);
        capsule.gameObject.SetActive(true);
    }
}
