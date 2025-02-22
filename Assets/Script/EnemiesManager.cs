using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    // Singleton pattern
    public static EnemiesManager instance;
    
    // List to track all enemies
    public List<Enemy> enemies;
    public UnityEvent onChanged;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onChanged.Invoke();
    }

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