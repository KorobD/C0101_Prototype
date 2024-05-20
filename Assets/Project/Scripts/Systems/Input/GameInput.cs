using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput instance { get; private set; }

    private InputSystem _inputSystem;

    public static Action OnMoveLeft;
    public static Action OnMoveRight;

    private void OnEnable()
    {
        instance = this;
        _inputSystem = new InputSystem();
        _inputSystem.Player.Enable();
        _inputSystem.Player.MoveLeft.performed += MoveLeft_performed;
        _inputSystem.Player.MoveRight.performed += MoveRight_performed;
    }

    private void OnDisable()
    {
        _inputSystem.Player.MoveLeft.performed -= MoveLeft_performed;
        _inputSystem.Player.MoveRight.performed -= MoveRight_performed;
    }

    private void MoveLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMoveLeft?.Invoke();
    }
    
    private void MoveRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMoveRight?.Invoke();
    }
}
