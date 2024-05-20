using UnityEngine;

public class DeadScreen : MonoBehaviour
{

    [SerializeField] private GameObject _deadScreen;

    private void OnEnable()
    {
        GameState.OnGameOver += ShowDeadScreen;
    }

    private void Awake()
    {
        
        HideDeadScreen();
    }

    private void OnDisable()
    {
        GameState.OnGameOver -= ShowDeadScreen;
    }

    private void ShowDeadScreen()
    {
        _deadScreen.SetActive(true);
    }

    private void HideDeadScreen()
    {
        _deadScreen.SetActive(false);
    }
}
