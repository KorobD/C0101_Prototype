using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _recordScore;

    private void Awake()
    {
        _startButton.onClick.AddListener(() =>
        {
            Loader.Load(ScenesList.Game);
        });
        _recordScore.text = SaveLoadScore.LoadScore().ToString();
    }
}
