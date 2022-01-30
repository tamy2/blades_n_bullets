using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]

public class SpearController : EnemyController
{
    public void Update() {
        checkDeath();
        if (Mathf.Abs((swordPos.position - rb.position).magnitude) <= Mathf.Abs((gunPos.position - rb.position).magnitude)) {
            target = swordPos.position;
        } else {
            target = gunPos.position;
        }
        moveTowardsPosition(tip.position);
        rotateTowardsPosition(target);
    }
    
}
