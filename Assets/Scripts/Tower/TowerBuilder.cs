using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        beam.transform.localScale = new Vector3(1f, beamHeight, 1f);
        Vector3 _startPosition = beam.transform.position + new Vector3(0, (_levelCount * _distancebetweenPlatform - _additionalBeamHeight) / 2f - _distancebetweenPlatform, 0);

        SpawnPlatform(_startPlatform, transform, ref _startPosition);

        for (int i = 0; i < _levelCount - 2; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], transform, ref _startPosition);
        }

        SpawnPlatform(_endPlatform, transform, ref _startPosition);
    }

    private void SpawnPlatform(Platform platform, Transform parent, ref Vector3 position)
    {
        Instantiate(platform, position, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        position.y = position.y - _distancebetweenPlatform;
    }

}
