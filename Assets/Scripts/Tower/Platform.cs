using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    private float _bounceForce = 100f;

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach (var segment in segments)
        {
            Vector3 forceDirection = (segment.transform.position - transform.position).normalized * _bounceForce;
            // Debug.DrawLine(transform.position, segment.transform.position, Color.red, 2000f, false);
            segment.Bounce(forceDirection);
        }
        transform.parent = null;
    }

}
