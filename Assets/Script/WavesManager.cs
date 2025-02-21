using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    // Singleton pattern
    public static WavesManager instance;
    
    // List to track all wave spawners
    public List<WaveSpawner> waves;

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