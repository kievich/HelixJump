using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlatformSegment>(out PlatformSegment platform))
        {
            //_rigidbody.AddForce(0, _force, 0, ForceMode.Impulse);

        }
    }



}
