using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreTextDeadScreen;
    private int _score;
    private int _saveScore;
    private bool _canPlay;

    
    private void OnEnable()
    {
        GameState.OnGamePlaying += OnCanPlay;
        GameState.OnGameOver += OnDontPlay;
    }
    
    private void Start()
    { 
        _saveScore = PlayerPrefs.GetInt("RecordScore");
        StartCoroutine(AddScoreTimer());
    }

    private IEnumerator AddScoreTimer()
    {
        while (true)
        {
            AddScore(1);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void AddScore(int count)
    {
        if(!_canPlay) return;
        _score += count;
        _scoreText.text = _score.ToString();
    }
    
    private void OnCanPlay()
    {
        _canPlay = true;
    }

    private void OnDontPlay()
    {
        _canPlay = false;
        _scoreTextDeadScreen.text = _scoreText.text;
        RecordCheck();
    }

    private void RecordCheck()
    {
        if (_score > _saveScore)
        {
            SaveLoadScore.SaveScore(_score);
        }
    }
}
