using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    public int destroyTime;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //Destroy(gameObject, 0.1f);
    }
}
