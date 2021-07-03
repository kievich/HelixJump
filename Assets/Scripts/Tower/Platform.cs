using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach (var segment in segments)
        {
            segment.Bounce();
        }
        transform.parent = null;
    }

}
