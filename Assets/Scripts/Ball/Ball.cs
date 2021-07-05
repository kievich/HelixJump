using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private CameraBounce _camera;

    private void Start()
    {
        _camera = FindObjectOfType<CameraBounce>();
    }

    private void OnTriggerEnter(Collider PlatformTrigger)
    {

        if (PlatformTrigger.TryGetComponent<EndPlatform>(out EndPlatform endPlatform))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PlatformTrigger.GetComponentInParent<Platform>().Break();
            _camera.CanCameraBounce = true;
        }
    }
}
