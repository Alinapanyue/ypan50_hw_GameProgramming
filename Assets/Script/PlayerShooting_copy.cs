using UnityEngine;
using UnityEngine.InputSystem;
/*
public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    public int bulletsAmount;
    public float fireRate = 0.5f;

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            InvokeRepeating("Shoot", 0f, fireRate);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void Shoot()
    {
        if (bulletsAmount > 0 && Time.timeScale > 0)
        {
            bulletsAmount--;

            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            muzzleEffect.Play();
            shootSound.Play();
        }
    }
}
*/