using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]

public class EnemyController : MonoBehaviour
{ 
    public Rigidbody rb;
    public HealthManager healthManager;
    //public int fullHealth;
    //public int currentHealth;
    public float enemySpeed;
    public float rotationSpeed;
    Quaternion targetRot;
    public PlayerControllerSword sword;
    public PlayerControllerGun gun;
    public Transform swordPos;
    public Transform gunPos;
    public Transform tip;
    public Vector3 target;

    /*public EnemyController() {

    }*/

    // Start is called before the first frame update
    void Start() {
        //FindObjectOfType(PlayerControllerSword).transform;
        sword = (PlayerControllerSword) FindObjectOfType(typeof(PlayerControllerSword));
        gun = (PlayerControllerGun) FindObjectOfType(typeof(PlayerControllerGun));
        swordPos = sword.transform;
        gunPos = gun.transform;
    }

    // Update is called once per frame
    /*protected virtual void Update() {

    }*/

    public void moveTowardsPosition(Vector3 destination) {
        //rb.velocity = (destination - rb.position)*enemySpeed;
        rb.position = Vector3.MoveTowards(rb.position, destination, Time.deltaTime * enemySpeed);
    }

    public void rotateTowardsPosition(Vector3 destination) {
        Vector3 move = Vector3.Normalize(destination - rb.position);
        if (move.magnitude > 0) {
            targetRot = Quaternion.LookRotation(move, Vector3.up);
        }
        transform.rotation = Quaternion.Lerp(rb.rotation, targetRot, Time.deltaTime * rotationSpeed);
    }

    public void checkDeath() {
        if (healthManager.GetHealth() <= 0) {
            Destroy(gameObject);
            //explodey effect mayhaps? Only visually for enemies but actualy impact for grenade
        }
    }
}
