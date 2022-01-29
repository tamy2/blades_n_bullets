using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public bool isEnemy;
    public HealthManager healthManager;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    /*
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Hitbox>() != null) {
            if (other.gameObject.tag == "player") {
                //player damages everything
            }
            if (other.gameObject.tag == "enemy") {
                if (gameObject.tag == "player") {
                    //enemies don't hurt themselves
                }
            }
        }
    }
    */


}