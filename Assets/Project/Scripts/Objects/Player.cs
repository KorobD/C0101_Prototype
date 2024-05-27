using UnityEngine;

public class Player : MonoBehaviour
{

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        Spawner.OnCG += UpdateBoxCollader;
    }
    private void OnDisable()
    {
        Spawner.OnCG -= UpdateBoxCollader;
    }

    private void UpdateBoxCollader()
    {
        _boxCollider.size = new Vector3(7f, 1f, 14f);
        Spawner.OnCG -= UpdateBoxCollader;
    }
}
