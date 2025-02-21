using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;  // Points awarded when enemy is killed

    void OnDestroy()
    {
        // Add points to ScoreManager when enemy is destroyed
        ScoreManager.instance.amount += amount;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
