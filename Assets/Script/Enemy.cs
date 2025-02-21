using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        // Add this enemy to the manager's list when it starts
        if (EnemyManager.instance != null)
        {
            EnemyManager.instance.enemies.Add(this);
        }
    }

    void OnDestroy()
    {
        // Optional: Remove from list when destroyed
        if (EnemyManager.instance != null)
        {
            EnemyManager.instance.enemies.Remove(this);
        }
    }
}