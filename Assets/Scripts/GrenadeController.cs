using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : EnemyController
{
    public Transform explosion;
    //public float fallSpeed;
    public void Update() {
        //checkDeath();
        target = rb.position + new Vector3(0, 0, -1);
        moveTowardsPosition(target);
        //moveTowards(transform.position, target, Time.deltaTime * fallSpeed);
    }

    /*override public void CheckDeath() {
        Explode();
    }*/

    public void Explode() {
        Transform explode = Instantiate(explosion, rb.position, transform.rotation);
        Destroy(gameObject);
        //explosion.isPlaying = true;

        //disable everything, enable explosion for 0.2 seconds
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger activated by " + other.tag);
        if (other.tag == "ExplodeOnImpact")
        {
            Explode();
        }
    }
}
