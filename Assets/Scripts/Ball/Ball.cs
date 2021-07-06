using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    [System.NonSerialized] public BallStates State = BallStates.Falling;

    public event Action Fall;

    private void OnTriggerEnter(Collider PlatformTrigger)
    {

        if (PlatformTrigger.TryGetComponent<EndPlatform>(out EndPlatform endPlatform))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PlatformTrigger.GetComponentInParent<Platform>().Break();
            Fall?.Invoke();
        }
    }
}
