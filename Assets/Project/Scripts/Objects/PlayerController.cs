using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 70f;
    private float3 _targetPos;
    private float _laneOffset = 11f;
    private bool _canPlay;
    private void OnEnable()
    {
        GameInput.OnMoveLeft += OnMoveLeft;
        GameInput.OnMoveRight += OnMoveRight;
        Spawner.OnCG += UpdateMoveSpeed;
        GameState.OnGamePlaying += OnCanPlay;
        GameState.OnGameOver += OnDontPlay;
    }

    private void Update()
    {
        GetTransformPosition();
    }


    private void OnDisable()
    {
        GameInput.OnMoveLeft -= OnMoveLeft;
        GameInput.OnMoveRight -= OnMoveRight;
        Spawner.OnCG -= UpdateMoveSpeed;
        GameState.OnGamePlaying -= OnCanPlay;
        GameState.OnGameOver -= OnDontPlay;
    }

    private void GetTransformPosition() {
        transform.position = Float3Extensions.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
    }
    
    private void OnMoveLeft() {
        if(!_canPlay) return;
        if (_targetPos.x > -_laneOffset)
        {
            _targetPos = new float3(_targetPos.x - _laneOffset, transform.position.y, transform.position.z);
        }
    }

    private void OnMoveRight() {
        if(!_canPlay) return;
        if (_targetPos.x < _laneOffset) 
        {
            _targetPos = new float3(_targetPos.x + _laneOffset, transform.position.y, transform.position.z);
        }
    }

    private void OnCanPlay()
    {
        _canPlay = true;
    }

    private void OnDontPlay()
    {
        _canPlay = false;
    }
    
    private void UpdateMoveSpeed()
    {
        _moveSpeed = 90f;
        Spawner.OnCG -= UpdateMoveSpeed;
    }

}
