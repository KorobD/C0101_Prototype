using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeadScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _mainMenu;
    
    private void Awake()
    {
        _restart.onClick.AddListener(() =>
        {
            Loader.Load(ScenesList.Game);
        });
        
        _mainMenu.onClick.AddListener(() =>
        {
            Loader.Load(ScenesList.MainMenu);
        });
    }
}
