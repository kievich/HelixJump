using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallGravity : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 1.0f;

    private float _globalGravity = -9.81f;

    Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = _globalGravity * _gravityScale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Force);
        if (_rigidbody.velocity.y < -5f)
        {
            _rigidbody.velocity = new Vector3(0, -5f, 0);
        }
    }
}
