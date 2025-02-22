using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;
    public float endTime;
    public float startTime;
    // Start is called before the first frame update
    private void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
