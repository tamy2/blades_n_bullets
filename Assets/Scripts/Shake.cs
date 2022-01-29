using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    Vector2 currentOffset;

    public Vector2 GetOffset()
    {
        return currentOffset;
    }

    public IEnumerator DoShake(float time, float power)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentOffset += Random.insideUnitCircle * power * (1 - currentTime / time);
            currentTime += Time.deltaTime;



            currentOffset = Vector2.Lerp(currentOffset, Vector2.zero, Time.deltaTime * 5);
            yield return null;
        }
        currentOffset = Vector2.zero;
    }
}
