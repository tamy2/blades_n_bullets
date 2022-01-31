using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool isEnemy;
    public bool oneHit; //does hitbox dissipate
    public bool friendlyFire;
    public int damage;
    public bool destroyOnHit;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (transform.parent == other.transform.parent)
        {
            print("Returned on: " + transform.parent.name + " hit " + other.transform.name);

            return;
        }

        print(transform.parent.name + " hit " + other.transform.name);

        Hurtbox opponent = other.GetComponent<Hurtbox>();
        if (opponent != null)
        {
            if (isEnemy != opponent.isEnemy || friendlyFire)
            {
                opponent.FlashModel();
                if (opponent.healthManager)
                {
                    opponent.healthManager.takeDamage(damage);
                }
                opponent.PlaySound();
                CameraShake.instance.Shake();
                if (destroyOnHit)
                {
                    Destroy(transform.parent.gameObject);
                }
                //print(other + "took damage");
                //player hitbox hits everyone
                //other.GetComponent<Hurtbox>.knockbackManager.knockback(vector);
            }
            /*} else if (other.GetComponent<Hurtbox>().isEnemy == false) {
                //means hitbox belongs to enemy but hurtbox to player
                other.GetComponent<Hurtbox>().healthManager.takeDamage(damage);
            }*/
            //destroy hurtbox depending on type? Bullet will disappear, sword will still be there
        }//}
    }
}
