using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSword : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange;
    private CharacterController controller;
    public float playerSpeed;
    public Rigidbody rb;
    //private Vector3 playerVelocity;

    private void Start()
    {

    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = playerSpeed*move;
        //speed up? slow down?
        //controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            //Attack();
        }


        /*if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }*/

        //controller.Move(playerVelocity * Time.deltaTime);
    }
}