using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static Action OnPlayerCrashed;
    
    private void OnTriggerEnter(Collider other)
    {
        OnPlayerCrashed?.Invoke();
        PlayerCrashed();
    }

    private void PlayerCrashed()
    {
        gameObject.SetActive(false);
    }
}
