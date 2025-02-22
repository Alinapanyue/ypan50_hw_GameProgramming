using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WavesManager : MonoBehaviour
{
    // Singleton pattern
    public static WavesManager instance;
    
    // List to track all wave spawners
    public List<WaveSpawner> waves;
    public UnityEvent onChanged; 

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

    public void AddWave(WaveSpawner wave)    // New method
    {
        waves.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)  // New method
    {
        waves.Remove(wave);
        onChanged.Invoke();
    }
}