using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Destroy both the bullet and what it hit
        Destroy(gameObject);           // Destroys this bullet
        Destroy(other.gameObject);     // Destroys what the bullet hit
    }
}