using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float trailingValueDelay;
    public Transform currentValueBar;
    public Transform trailingValueBar;

    private float timeSinceHit;
    private float trailingValue;
    private float currentValue;
    private Vector3 basePos;

    private float health = 1;

    public Shake shake;

    void Start()
    {
        trailingValue = 1;
        currentValue = 1;
        basePos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnDamageTaken(currentValue / 2);
        }

        timeSinceHit += Time.deltaTime;

        if (timeSinceHit > trailingValueDelay)
        {
            trailingValue = Mathf.Lerp(trailingValue, currentValue, Time.deltaTime * 8f);
            trailingValueBar.localScale = new Vector3(trailingValue, 1, 1);
        }

        if (shake != null)
        {
            transform.position = basePos + (Vector3)shake.GetOffset();
        }
    }

    void OnDamageTaken(float ratio)
    {
        timeSinceHit = 0;
        currentValue = ratio;
        currentValueBar.localScale = new Vector3(currentValue, 1, 1);
        StartCoroutine(shake.DoShake(0.3f, 5));
    }
}
