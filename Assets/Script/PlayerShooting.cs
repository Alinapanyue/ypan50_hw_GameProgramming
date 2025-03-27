using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;  // Reference to the muzzle flash particle system

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            // Spawn the projectile
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            
            // Play the muzzle effect with null check
            if (muzzleEffect != null)
            {
                muzzleEffect.Play();
            }
        }
    }
}