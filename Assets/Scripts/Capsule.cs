using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Capsule : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public event Action<Capsule> OnWallCollision;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out _))
        {
            OnWallCollision?.Invoke(this);
        }
    }
}
