using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]

public class SpearController : EnemyController
{
    public void Update() {
        checkDeath();
        if (Mathf.Abs((sword.position - rb.position).magnitude) <= Mathf.Abs((gun.position - rb.position).magnitude)) {
            target = sword.position;
        } else {
            target = gun.position;
        }
        moveTowardsPosition(tip.position);
        rotateTowardsPosition(target);
    }
    
}
