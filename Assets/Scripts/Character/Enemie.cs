using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    public float Hp;
    public float AttackRange = 2;
    public bool IsBig = false;
    public bool IsInAttackRange = false;
    private float startHp;
    private NavMeshAgent agent;
    private Animator animatorController;
    private bool isDead = false;

    private void Start()
    {
        startHp = Hp;
        agent = GetComponent<NavMeshAgent>();
        animatorController = GetComponent<Animator>();
        SceneManager.Instance.AddEnemie(this);
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            Die();
            agent.isStopped = true;
            return;
        }

        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
        IsInAttackRange = distance <= AttackRange;
    }

    private void Die()
    {
        if (IsBig)
        {
            SceneManager.Instance.EnemiesFactory.SpawnSmallEnemy(gameObject.transform.position);
            SceneManager.Instance.EnemiesFactory.SpawnSmallEnemy(gameObject.transform.position);
        }
        
        AddHealthOnEnemyKill();
        GetComponent<EnemyMoveController>().enabled = false;
        GetComponent<EnemyAttackController>().enabled = false;
        SceneManager.Instance.RemoveEnemie(this);
        isDead = true;
        animatorController.SetTrigger("Die");
    }

    private void AddHealthOnEnemyKill()
    {
        Debug.Log(SceneManager.Instance.Player.Hp);
        SceneManager.Instance.Player.Hp += startHp / 2;
        Debug.Log(SceneManager.Instance.Player.Hp);
    }

}
