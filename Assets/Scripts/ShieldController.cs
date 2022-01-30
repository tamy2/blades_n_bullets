using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : EnemyController
{
    public int distanceFromGun;
    public void Update() {
        checkDeath();
        //actively stay in front of gun?
        /*if (Mathf.Abs((swordPos.position - rb.position).magnitude) <= Mathf.Abs((gunPos.position - rb.position).magnitude)) {
            target = swordPos.position;
        } else {
            target = gunPos.position;
        }*/
        target = gun.transform.position + Vector3.Normalize(gun.transform.right) * distanceFromGun;
        moveTowardsPosition(target);
        //rotateTowardsPosition(target);
    }
}
