using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGun : MonoBehaviour
{
    //private CharacterController controller;
    public Transform bullet;
    public LayerMask clickable;
    public Transform tip;
    //public UnityEngine.AI.NavMeshAgent agent;
    Vector3 newPosition;
    public float playerSpeed;
    public float shotForce;
    //private Vector3 targetPosition;
    //private float playerSpeed = 2.0f;


    private void Start()
    {
        newPosition = transform.position;
        //agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        //print(transform.position + "\n");
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

        Vector3 right = getMousePosition() - transform.position;
        right.y = 0;
        transform.right = right;

        if (Input.GetMouseButtonDown(0))
        {
            GetComponentInChildren<GunModel>().PlayAnimation();
            Transform shotBullet = Instantiate(bullet, tip.position, transform.rotation);
            shotBullet.GetComponent<Rigidbody>().velocity = shotBullet.right * shotForce;
        }
        if (Input.GetMouseButtonDown(1))
        {
            newPosition = getMousePosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * playerSpeed);
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    /*void MoveTo(Transform player, Vector3 destination) {
        while (transform.position != destination) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, playerSpeed);
            yield return new WaitForSeconds(0.2f);
        }
    }*/

    Vector3 getMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500, clickable))
        {
            Vector3 mousePosition = hit.point;
            mousePosition.y = 5;
            return mousePosition;

        }
        return Vector3.zero;
    }
}