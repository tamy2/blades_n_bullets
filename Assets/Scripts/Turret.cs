using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyController
{
    public float shotFrequency;
    public Transform bulletPrefab;
    public float shotForce;
    // public Transform tip;

    private float timeToShot;

    void Update()
    {
        if (Mathf.Abs((sword.position - rb.position).magnitude) <= Mathf.Abs((gun.position - rb.position).magnitude))
        {
            target = sword.position;
        }
        else
        {
            target = gun.position;
        }

        rotateTowardsPosition(target);

        timeToShot -= Time.deltaTime;
        if (timeToShot <= 0)
        {
            ShootBullet();
            timeToShot = shotFrequency;
        }
    }

    void ShootBullet()
    {
        Transform shotBullet = Instantiate(bulletPrefab, tip.position, transform.rotation);
        shotBullet.GetComponent<Rigidbody>().velocity = shotBullet.right * shotForce;
    }
}
