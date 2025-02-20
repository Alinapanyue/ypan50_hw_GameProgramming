using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject prefab;        // Enemy bullet prefab
    public float fireRate = 3f;      // Shoot every 3 seconds (slower than player)
    private float nextFireTime = 0f;
    public float bulletSpeed = 5f;   // Slower bullets than player

    void Update()
    {
        // Automatic shooting with time interval
        if (Time.time > nextFireTime)
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
            
            // Optional: Add force to bullet if it has a Rigidbody
            if (clone.GetComponent<Rigidbody>())
            {
                clone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
            
            nextFireTime = Time.time + fireRate;  // Set next shot time
        }
    }
}
