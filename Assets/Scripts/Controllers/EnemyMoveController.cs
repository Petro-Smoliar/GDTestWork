using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animatorController;
    private Enemie enemie;

    private void Start()
    {
        enemie = GetComponent<Enemie>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(SceneManager.Instance.Player.transform.position);
        animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemie.IsInAttackRange)
        {
            agent.isStopped = true;
        }
        else 
        {
            agent.isStopped = false;
            agent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        animatorController.SetFloat("Speed", agent.speed);
    }
}