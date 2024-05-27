using System;
using TMPro;
using UnityEngine;

public class GameStartCountdown : MonoBehaviour
{
   [SerializeField] private TMP_Text _countdownText;
   private float _countdownToStartTimer = 3;
   public static Action OnCountdownEnding;

   private void OnEnable()
   {
      GameState.OnCountdownToStart += CountdownToStart;
   }
   
   private void Awake()
   {
      CountdownToStart();
   }

   private void Update()
   {
      Timer();
   }
   
   private void OnDisable()
   {
      GameState.OnCountdownToStart -= CountdownToStart;
   }

   private void CountdownToStart()
   {
      Show();
   }

   private void Timer()
   {
      _countdownToStartTimer -= Time.deltaTime;
      _countdownText.text = Mathf.Ceil(_countdownToStartTimer).ToString();
      if (_countdownToStartTimer < 0)
      {
         OnCountdownEnding?.Invoke();
         Hide();
      }
   }


   private void Show()
   {
      gameObject.SetActive(true);
   }

   private void Hide()
   {
      gameObject.SetActive(false);
   }
   
}
