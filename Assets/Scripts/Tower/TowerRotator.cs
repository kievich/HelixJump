using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = -(touch.deltaPosition.x * _rotateSpeed * Time.deltaTime);
                transform.Rotate(new Vector3(0, torque, 0));
            }
        }
    }
}
