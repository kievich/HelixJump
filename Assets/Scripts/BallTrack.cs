using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrack : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    [SerializeField] private Vector3 _positionOffset;

    private Ball _ball;
    private Beam _beam;

    private Vector3 _minBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();
        _minBallPosition = _ball.transform.position;
    }
    private void Update()
    {
        if (_ball.transform.position.y < _minBallPosition.y)
        {
            Track();
            _minBallPosition = _ball.transform.position;
        }

    }

    private void Track()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;

        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        transform.position = _ball.transform.position - direction * _lenght;
        transform.LookAt(_ball.transform);
        transform.position -= _positionOffset;

    }

}
