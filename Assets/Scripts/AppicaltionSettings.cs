using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppicaltionSettings : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate;

    private void Start()
    {
        Application.targetFrameRate = _targetFrameRate;
    }

}
