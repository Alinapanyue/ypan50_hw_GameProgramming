using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    { 
        GoToBase,
        AttackBase,
        ChasePlayer,
        AttackPlayer
    }

    public float lastShootTime;
    public GameObject bulletPrefab;
    public float fireRate;

    public EnemyState currentState;
    public Sight sightSensor;  // Reference to our existing Sight component
    private NavMeshAgent agent;

    void Start()
    {
        // Get NavMeshAgent component
    agent = GetComponent<NavMeshAgent>();  // Try on same GameObject first
    if (agent == null)
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    
    if (agent == null)
    {
        Debug.LogError("NavMeshAgent not found!");
        enabled = false;
        return;
    }

    // Verify agent is on NavMesh
    if (!agent.isOnNavMesh)
    {
        Debug.LogError("Enemy is not placed on NavMesh!");
        enabled = false;
        return;
    }

    }

    void Awake()
    {
        // Find base first
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
            if (baseTransform == null)
        {
            Debug.LogError("BaseDamagePoint not found!");
            enabled = false;
        }
        
    }

    void Update()
    {
        if (currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else { AttackPlayer(); }

        //DEBUG
        Debug.Log("current state is: " + currentState);
    }

    public Transform baseTransform;
    public float baseAttackDistance;
    void GoToBase()
    {
        if (agent == null || !agent.isOnNavMesh) return;
    
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }

    }

    void AttackBase()
{
    agent.isStopped = true;
    Shoot();
    
    // Add this to check for state transitions
    if (sightSensor.detectedObject != null)
    {
        currentState = EnemyState.ChasePlayer;
        return;
    }
    
    // Add this to check if we're too far from base
    float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
    if (distanceToBase > baseAttackDistance * 1.1f)
    {
        currentState = EnemyState.GoToBase;
    }
}

    public float playerAttackDistance;
    void ChasePlayer()
    {
        agent.isStopped = false;
       if (sightSensor.detectedObject == null)
       {
        currentState = EnemyState.GoToBase;
        return;
       }
       agent.SetDestination(sightSensor.detectedObject.transform.position);
       
       float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
       if (distanceToPlayer <= playerAttackDistance)
       {
        currentState = EnemyState.AttackPlayer;
       }
       
    }



    void AttackPlayer()
    {
        agent.isStopped = true;
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        Shoot();

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
              
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
        lastShootTime = Time.time;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

}