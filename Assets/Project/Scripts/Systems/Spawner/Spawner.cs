using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float3[] _points;
    private float3 _spawnPos1;
    private float3 _spawnPos2;
    private bool _canPlay;
    [SerializeField] private float _spawnRate;
    [SerializeField] private PoolObjects _poolObjects;
    private Coroutine _spawnCoroutine;

    public static Action OnCG;


    private void OnEnable()
    {
        GameState.OnGamePlaying += StartProcessSpawn;
        GameState.OnGameOver += StopProcessSpawn;
        DifficultyLvL.OnUpdateDifficultyLevel += UpdateSpawnRate;
    }

    private void Start()
    {
        _points = new float3[3];
        _points[0] = new float3(11f, 0.3f, 375f);
        _points[1] = new float3(0f, 0.3f, 375f);
        _points[2] = new float3(-11f, 0.3f, 375f);

    }

    private void OnDisable()
    {
        GameState.OnGamePlaying -= StartProcessSpawn;
        GameState.OnGameOver -= StopProcessSpawn;
        DifficultyLvL.OnUpdateDifficultyLevel -= UpdateSpawnRate;
    }
    private IEnumerator ProcessSpawn()
    {
        while (true)
        {
            PointSelection();
            _poolObjects.CreateObject(_spawnPos1);
            _poolObjects.CreateObject(_spawnPos2);
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void PointSelection()
    {
        int ndx1 = Random.Range(0, _points.Length);
        _spawnPos1 = _points[ndx1];
        float3[] remainingPoints = new float3[_points.Length - 1];
        int remainingIndex = 0;
        for (int i = 0; i < _points.Length; i++)
        {
            if (i != ndx1)
            {
                remainingPoints[remainingIndex] = _points[i];
                remainingIndex++;
            }
        }

        int index2 = Random.Range(0, remainingPoints.Length);
        _spawnPos2 = remainingPoints[index2];
    }
    
    private void StartProcessSpawn()
    {
        if (_spawnCoroutine == null)
        {
            _spawnCoroutine = StartCoroutine(nameof(ProcessSpawn));
        }
    }

    private void StopProcessSpawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    
    private void UpdateSpawnRate()
    {
        if (_spawnRate > 0.6)
        {
            _spawnRate -= 0.3f;
        }
        else
        {
            OnCG?.Invoke();
        }
    }
}

