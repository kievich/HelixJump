using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Platform
{
    [SerializeField] Ball _ball;
    [SerializeField] GameObject _spawnpoint;

    private void Awake()
    {
        Instantiate(_ball, _spawnpoint.transform.position, Quaternion.identity);

    }

}
