using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    
    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            // Create bullet at shootPoint position AND rotation
            GameObject clone = Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
            
            // Make bullet's forward direction match shootPoint's forward
            clone.transform.forward = shootPoint.transform.forward;
        }
    }
}
