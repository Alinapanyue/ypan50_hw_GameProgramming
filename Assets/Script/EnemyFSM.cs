using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public ParticleSystem muzzleEffect;
    private Animator animator;  // Added animator reference
    
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
    public Sight sightSensor;
    private NavMeshAgent agent;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;

    void Awake()
    {
        // Find base first
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        if (baseTransform == null)
        {
            Debug.LogError("BaseDamagePoint not found!");
            enabled = false;
        }
        
        // Get components from parent
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();  // Added animator caching
    }

    void Start()
    {
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found!");
            enabled = false;
            return;
        }

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Enemy is not placed on NavMesh!");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (currentState == EnemyState.GoToBase) { GoToBase(); }
        else if (currentState == EnemyState.AttackBase) { AttackBase(); }
        else if (currentState == EnemyState.ChasePlayer) { ChasePlayer(); }
        else { AttackPlayer(); }
    }

    void GoToBase()
    {
        if (agent == null || !agent.isOnNavMesh) return;
    
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        
        // Update animator
        if (animator != null)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsShooting", false);
        }

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
        
        // Update animator
        if (animator != null)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsShooting", true);
        }

        Shoot();
        
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }
        
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase > baseAttackDistance * 1.1f)
        {
            currentState = EnemyState.GoToBase;
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        
        // Update animator
        if (animator != null)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsShooting", false);
        }

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
        
        // Update animator
        if (animator != null)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsShooting", true);
        }

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

    void Shoot()
    {
        if (Time.timeScale <= 0) return;
        
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            if (muzzleEffect != null)
            {
                muzzleEffect.Play();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}