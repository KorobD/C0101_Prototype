using Unity.Mathematics;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private float _moveSpeed;

    private void OnEnable()
    {
        _moveSpeed = ObjectSettings.Instance.MoveSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float3 currentPosition = transform.position;
        currentPosition.z -= _moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
