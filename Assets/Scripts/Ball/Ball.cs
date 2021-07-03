using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider PlatformTrigger)
    {

        PlatformTrigger.GetComponentInParent<Platform>().Break();
    }
}
