using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Action OnCountdownToStart;
    public static Action OnGamePlaying;
    public static Action OnGameOver;


    private void OnEnable()
    {
        PlayerBehaviour.OnPlayerCrashed += IsGameOver;
        GameStartCountdown.OnCountdownEnding += IsGamePlaying;
    }

    private void Start()
    {
        OnCountdownToStart?.Invoke();
    }

    private void IsGamePlaying()
    {
        OnGamePlaying?.Invoke();
    }

    private void  IsGameOver()
    {
        OnGameOver?.Invoke();
    }

}
