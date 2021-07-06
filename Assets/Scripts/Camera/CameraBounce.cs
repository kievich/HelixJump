using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraBounce : MonoBehaviour
{
    [SerializeField] private float _downMoveTime;
    [SerializeField] private float _upMoveTime;
    [SerializeField] private float _moveLength;
    [System.NonSerialized] public bool CanCameraBounce = false;
    public void Bounce()
    {
        if (CanCameraBounce)
        {
            StartCoroutine(doBounce());
            CanCameraBounce = false;
            //Time.timeScale = 0.1f;
        }

    }

    IEnumerator doBounce()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y - _moveLength, transform.position.z), _downMoveTime, false);
        yield return new WaitForSeconds(_downMoveTime);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + _moveLength, transform.position.z), _upMoveTime, false);

    }

}
