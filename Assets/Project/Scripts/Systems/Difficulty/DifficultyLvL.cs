using System;
using UnityEngine;

public class DifficultyLvL : MonoBehaviour
{
    [SerializeField] private int _difficultyLvL;
    private int _numberWallPassed;

    public static Action OnUpdateDifficultyLevel;

    private void OnEnable()
    {
        WallBehaviour.OnWallIsDeactivity += IncreasingDifficulty;
    }

    private void Awake()
    {
        _difficultyLvL = 1;
        _numberWallPassed = 0;
    }

    private void OnDisable()
    {
        WallBehaviour.OnWallIsDeactivity -= IncreasingDifficulty;
    }

    private void IncreasingDifficulty()
    {
        _numberWallPassed++;
        if (_numberWallPassed > 1)
        {
            if (_numberWallPassed % 20 == 0)
            {
                AddDifficultyLvL();
                OnUpdateDifficultyLevel?.Invoke();
            }
        }
    }

    private void AddDifficultyLvL() {
        _difficultyLvL += 1;
    }
}
