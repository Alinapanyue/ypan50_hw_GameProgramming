using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        // Add this enemy to the manager's list when it starts
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.AddEnemy(this);
        }
    }

    void OnDestroy()
    {
        // Optional: Remove from list when destroyed
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.RemoveEnemy(this);
        }
    }
}