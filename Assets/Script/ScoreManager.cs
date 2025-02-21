using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Static instance for Singleton pattern
    public int amount;                    // Score amount

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