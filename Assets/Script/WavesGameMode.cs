using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] LifePlayer playerLife;  // Reference to player's life component

    void Update()
    {
        // Check win condition - all enemies and waves are gone
        if (EnemyManager.instance.enemies.Count <= 0 && 
            WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

        // Check lose condition - player died
        if (playerLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void Start()
    {
        
    }
}