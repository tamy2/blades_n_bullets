using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModel : MonoBehaviour
{
    public GameObject bulletCasingPrefab;
    public Transform casingPosition;
    public Vector3 casingImpulse;
    public int casingForce;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger("shoot");
    }

    void SpawnBulletCasing()
    {
        Rigidbody bulletCasing = Instantiate(bulletCasingPrefab, casingPosition.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletCasing.AddTorque(casingImpulse * Random.Range(0.5f, 1.5f));
        bulletCasing.AddForce(transform.up * casingForce * Random.Range(0.5f, 1.5f));
    }
}
