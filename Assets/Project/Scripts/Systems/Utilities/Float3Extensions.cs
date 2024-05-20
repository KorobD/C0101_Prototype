using System;
using Unity.Mathematics;

public static class Float3Extensions
{
    public static float3 MoveTowards(float3 current, float3 target, float maxDistanceDelta)
    {
        float num1 = target.x - current.x;
        float num2 = target.y - current.y;
        float num3 = target.z - current.z;
        
        float d = num1 * num1 + num2 * num2 + num3 * num3;
        
        if (d == 0.0 || maxDistanceDelta >= 0.0 &&  d <=  maxDistanceDelta * maxDistanceDelta)
            return target;
        float num4 = (float)Math.Sqrt(d);
        return new float3(current.x + num1 / num4 * maxDistanceDelta, current.y + num2 / num4 * maxDistanceDelta, current.z + num3 / num4 * maxDistanceDelta);
    }
}
