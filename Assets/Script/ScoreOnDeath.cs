using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;  // Points awarded when enemy is killed
    private LifeEnemy life;

    void GivePoints()
    {
        // Add points to ScoreManager when enemy is destroyed
        ScoreManager.instance.amount += amount;
    }

    void OnDestroy()
    {
        // Good practice: unsubscribe when destroyed
        if (life != null)
        {
            life.onDeath.RemoveListener(GivePoints);
        }
    }

    private void Awake()
    {
        // Get the Life component and subscribe to its onDeath event
        life = GetComponent<LifeEnemy>();
        life.onDeath.AddListener(GivePoints);
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
