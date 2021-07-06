using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallTrack : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private float _fallingLengthToTrack;
    [SerializeField] private float _timeToDownCamera;

    private Ball _ball;
    private Beam _beam;

    private bool canTrack = true;


    private float _currentPositionToTrack;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _currentPositionToTrack = _ball.transform.position.y;
        _ball.Fall += onBallFalling;
        _ball.GetComponent<BallBounce>().Landed += onBallLanded;
    }
    private void Update()
    {
        if (canTrack && _ball.transform.position.y < _currentPositionToTrack)
            Track();
    }

    private void Track()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;

        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        transform.position = _ball.transform.position - direction * _lenght;
        transform.LookAt(_ball.transform);
    }

    public void PutDownCamera()
    {
        transform.DOMoveY(transform.position.y - _fallingLengthToTrack, _timeToDownCamera).SetEase(Ease.OutExpo);
    }

    private void onBallFalling()
    {
        canTrack = true;
        _ball.State = BallStates.Falling;
    }

    private void onBallLanded()
    {
        if (_ball.State == BallStates.Falling)
        {
            _ball.State = BallStates.Bouncing;
            onFirstBallLanded();
        }
    }
    private void onFirstBallLanded()
    {
        canTrack = false;
        _currentPositionToTrack = _ball.transform.position.y - _fallingLengthToTrack;
        PutDownCamera();
        Track();
        // Debug.Log(_ball.transform.position);
        //RaiseCamera();
    }

}
