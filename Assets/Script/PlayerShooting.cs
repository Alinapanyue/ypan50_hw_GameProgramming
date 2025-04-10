using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;  // Added audio source reference
    public int bulletsAmount;

    public void OnFire(InputValue value) 
    {
        if (value.isPressed && Time.timeScale > 0)  // Added bullet check
        {
            if (bulletsAmount > 0) {
                bulletsAmount--; // Reduce bullets by 1
            } // Added bullet check

            // Spawn the projectile
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            
            // Play the muzzle effect with null check
            if (muzzleEffect != null)
            {
                muzzleEffect.Play();
            }

            // Play the shoot sound
            shootSound.Play();
        }
    }
}