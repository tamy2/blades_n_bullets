using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGun : MonoBehaviour
{
    //private CharacterController controller;
    public LayerMask clickable;
    Vector3 newPosition;
    private Vector3 playerVelocity;
    //private float playerSpeed = 2.0f;

    private void Start()
    {
        newPosition = transform.position;
        print(transform.position + "\n");
        //controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);

        /*if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
            //maybe speed up and slow down when starting up/ending walk?
            playerVelocity.x = playerSpeed*Input.GetAxisRaw("Horizontal");
        } else {
            playerVelocity.x = 0
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
            playerVelocity.y = playerSpeed*Input.GetAxisRaw("Vertical");
        } else {
            playerVelocity.x = 0
        }*/

        /*if (move != Vector3.zero) {
            gameObject.transform.forward = move;
        }*/

        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, clickable)) {
                newPosition = hit.point;
                print(newPosition + "\n");
                transform.position = newPosition;
                print(transform.position + "\n");
            }
        }
        //controller.Move(playerVelocity * Time.deltaTime);
    }
}
