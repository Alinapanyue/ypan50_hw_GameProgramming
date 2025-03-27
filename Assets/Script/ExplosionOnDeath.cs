using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab;

    void Awake()
    {
        var life = GetComponent<LifeEnemy>();
        life.onDeath.AddListener(OnDeath);
    }
 void OnDeath()
    {
        if (particlePrefab != null)
        {
            Instantiate(particlePrefab,
                transform.position,
                transform.rotation);
        }
    }
}