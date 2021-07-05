using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private Beam _beam;
    [SerializeField] private EndPlatform _endPlatform;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private int _additionalBeamHeight;
    [SerializeField] private float _distancebetweenPlatform;

    private void Awake()
    {
        Build();
    }



    private void Build()
    {
        Beam beam = Instantiate(_beam, Vector3.zero, Quaternion.identity, transform);
        float beamHeight = (_levelCount * _distancebetweenPlatform + _additionalBeamHeight) / 2f;
        beam.transform.localScale = new Vector3(beam.transform.localScale.x, beamHeight, beam.transform.localScale.z);
        Vector3 _startPosition = beam.transform.position + new Vector3(0, (_levelCount * _distancebetweenPlatform - _additionalBeamHeight) / 2f - _distancebetweenPlatform, 0);

        SpawnPlatform(_startPlatform, transform, ref _startPosition, Quaternion.Euler(0, 45f, 0));

        for (int i = 0; i < _levelCount - 2; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], transform, ref _startPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }

        SpawnPlatform(_endPlatform, transform, ref _startPosition, Quaternion.identity);
    }

    private void SpawnPlatform(Platform platform, Transform parent, ref Vector3 position, Quaternion rotation)
    {
        Instantiate(platform, position, rotation, parent);
        position.y -= _distancebetweenPlatform;
    }

}
