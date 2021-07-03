using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            Debug.Log("!");
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(100f, transform.position, 50f);
            // rigidbody.gameObject.GetComponent<MeshCollider>().enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
