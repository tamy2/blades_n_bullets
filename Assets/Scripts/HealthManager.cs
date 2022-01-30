using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int fullHealth;
    private int currentHealth;
    public bool isEnemy;
    public HealthBar bar;

    /*
    public HealthManager(int health) {
        this.health = currentHealth;
    }
    */

    private void Start() {
        currentHealth = fullHealth;
    }

    public int GetHealth() {
        return currentHealth;
    }

    public void takeDamage(int damage) {
        currentHealth = currentHealth - damage;
        /*if (health <= 0) {
           gameOver(); 
        }*/
        float ratio = (float) currentHealth/ (float) fullHealth;
        if (ratio < 0) {
            ratio = 0;
        }
        if (isEnemy != true) {
            bar.OnDamageTaken(ratio);
        }
        //print(damage + " damage taken!");
        //print("current total health: " + currentHealth);
        //print("Full health: " + fullHealth);
        //print("current health ratio: " + currentHealth/fullHealth);
    }

    
}
