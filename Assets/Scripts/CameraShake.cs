using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    public Shake shake;
    public float shakeFactor;

    private Vector3 basePos;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        basePos = SequencingManager.instance.gameCameraTransform.position;
    }

    public void Shake(int strength = 1)
    {
        StartCoroutine(shake.DoShake(0.25f * strength, 5 * strength));
    }

    void Update()
    {
        if (shake.GetOffset().magnitude > 0)
        {
            transform.position = basePos + new Vector3(shake.GetOffset().x, 0, shake.GetOffset().y) * shakeFactor;
        }
    }
}
