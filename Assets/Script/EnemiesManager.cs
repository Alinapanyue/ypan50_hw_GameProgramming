using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Singleton pattern
    public static EnemyManager instance;
    
    // List to track all enemies
    public List<Enemy> enemies;

    void Awake()
    {
        // Singleton pattern check
        if (instance == null)
        {
            instance = this;              // Set this as the instance if none exists
        }
        else
        {
            Debug.LogError("Duplicated ScoreManager, ignoring this one", gameObject);  // Warning message
        }
    }
}