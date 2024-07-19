
using UnityEngine;
using UnityEngine.AI;

public class NPCAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Патрулирование
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Состояния
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Panda 3D").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Проверка поля зрения и области
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere (transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) RunAwayPlayer();
        if (playerInSightRange && playerInAttackRange) Shiting();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint искать
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Вычисления случайной точки в области
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void RunAwayPlayer()
    {
        agent.SetDestination(transform.position - player.position * 2f);
    }
    private void Shiting()
    {
        //Заставляет NPC не двигаться
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }
}
