using System;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    public static Action OnWallIsDeactivity;
    
    private void Update()
    {
        if (transform.position.z < -25f)
        {
            OnWallIsDeactivity?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
