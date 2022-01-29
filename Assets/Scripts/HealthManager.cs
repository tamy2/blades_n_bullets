using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;

    public HealthManager(int health) {
        this.health = health;
    }

    public int GetHealth() {
        return health;
    }

    public void takeDamage(int damage) {
        health = health - damage;
        /*if (health <= 0) {
           gameOver(); 
        }*/
        print(damage + " damage taken!");
    }
}
