using UnityEngine;

public class ObjectSettings : MonoBehaviour
{
    public static ObjectSettings Instance { get; private set; }
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed;}
    }

    private void OnEnable()
    {
        DifficultyLvL.OnUpdateDifficultyLevel += UpdateMoveSpeed;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        DifficultyLvL.OnUpdateDifficultyLevel -= UpdateMoveSpeed;
    }
    
    private void UpdateMoveSpeed()
    {
        if (_moveSpeed >= 190f) return;
        _moveSpeed += 15f;
    }
}
