using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce(Vector3 forceDirection)
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            //rigidbody.gameObject.GetComponent<MeshCollider>().enabled = false;
            rigidbody.AddForce(forceDirection, ForceMode.Impulse);
            //rigidbody.velocity = forceDirection;
            Destroy(gameObject, 1);
        }
    }
}
