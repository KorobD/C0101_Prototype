using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private PooledObject pooledObjectPrefab;

    private PoolMono<PooledObject> _pool;

    private void Start()
    {
        this._pool = new PoolMono<PooledObject>(this.pooledObjectPrefab, this._poolCount, this.transform);
    }

    public void CreateObject(float3 rPosition)
    {
        var example = this._pool.GetFreeElement();
        example.transform.position = rPosition;
    }
}
