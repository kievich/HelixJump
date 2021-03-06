using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallGravity : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 1.0f;
    private float _globalGravity = -9.81f;
    [SerializeField] private float _speedLimite = 8f;

    Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void Update()
    {
        if (_rigidbody.velocity.y < -_speedLimite)
            _rigidbody.velocity = new Vector3(0, -_speedLimite, 0);

    }

    private void FixedUpdate()
    {
        Vector3 gravity = _globalGravity * _gravityScale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Force);
    }
}
