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
    public int rotationSpeed;

    Quaternion targetRot;
    //private Vector3 playerVelocity;

    private void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = playerSpeed*move;
        if (move.magnitude > 0) {
            targetRot = Quaternion.LookRotation(move, Vector3.up);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
        // transform.forward = Vector3.Lerp(transform.forward, targetDir, Time.deltaTime * rotationSpeed);
        // if (Vector3.Dot(transform.forward, targetDir) == -1) {
        //    transform.forward = Quaternion.AngleAxis(0.1f, Vector3.up) * transform.forward; 
        // }    

        //speed up? slow down?
        //controller.Move(move * Time.deltaTime * playerSpeed);

  
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.rotation = Quaternion.LookRotation(move);
  
  
        //transform.Translate(movement * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponentInChildren<SwordModel>().PlayAnimation();
            //Attack();
        }


        /*if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }*/

        //controller.Move(playerVelocity * Time.deltaTime);
    }
}