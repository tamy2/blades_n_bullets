using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public Rigidbody rb;
    public HealthManager healthManager;
    public int fullHealth;
    private int currentHealth;
    public float enemySpeed;
    public float rotationSpeed;
    Quaternion targetRot;
    public Transform sword;
    public Transform gun;
    public Transform tip;
    private Vector3 target;

    // Start is called before the first frame update
    private void Start() {
       currentHealth = fullHealth;
    }

    // Update is called once per frame
    void Update() {
        if (healthManager.GetHealth() <= 0) {
            //destroy
            //explodey effect mayhaps
        }
        if (Mathf.Abs((sword.position - rb.position).magnitude) <= Mathf.Abs((gun.position - rb.position).magnitude)) {
            target = sword.position;
        } else {
            target = gun.position;
        }
        moveTowardsPosition(tip.position);
        rotateTowardsPosition(target);
    }

    void moveTowardsPosition(Vector3 destination) {
        //rb.velocity = (destination - rb.position)*enemySpeed;
        rb.position = Vector3.MoveTowards(rb.position, destination, Time.deltaTime * enemySpeed);
    }

    void rotateTowardsPosition(Vector3 destination) {
        Vector3 move = Vector3.Normalize(destination - rb.position);
        if (move.magnitude > 0) {
            targetRot = Quaternion.LookRotation(move, Vector3.up);
        }
        transform.rotation = Quaternion.Lerp(rb.rotation, targetRot, Time.deltaTime * rotationSpeed);
    }
}
