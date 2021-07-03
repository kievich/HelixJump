using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _velocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlatformSegment>(out PlatformSegment platform))
        {
            if (platform.GetComponent<Rigidbody>().isKinematic)
                _rigidbody.velocity = new Vector3(0, _velocity, 0);

        }
    }



}
