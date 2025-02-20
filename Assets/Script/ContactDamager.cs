using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public float damage;    // Amount of damage to deal

    void OnTriggerEnter(Collider other)
{
    // Try both types of Life components
    LifePlayer playerLife = other.GetComponent<LifePlayer>();
    LifeEnemy enemyLife = other.GetComponent<LifeEnemy>();
    
    // Damage whichever one we found
    if (playerLife != null)
    {
        playerLife.amount -= damage;
        Debug.Log("Player hit! Life: " + playerLife.amount); // Debug line
    }
    else if (enemyLife != null)
    {
        enemyLife.amount -= damage;
        Debug.Log("Enemy hit! Life: " + enemyLife.amount); // Debug line
    }
    
    Destroy(gameObject);    // Destroy the bullet
}
}