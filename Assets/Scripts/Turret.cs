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
        checkDeath();

        if (Mathf.Abs((sword.transform.position - rb.position).magnitude) <= Mathf.Abs((gun.transform.position - rb.position).magnitude))
        {
            target = sword.transform.position;
        }
        else
        {
            target = gun.transform.position;
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
        Transform shotBullet = Instantiate(bulletPrefab, tip.position, tip.rotation);
        shotBullet.GetComponent<Rigidbody>().velocity = shotBullet.right * shotForce;
    }
}
