using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hp;
    public Animator AnimatorController;
    public PlayerAttackController attackController;
    public float AttackRange = 2f;
    public List<Enemie> Enemies;
    private bool isDead = false;

    public void EndAttack()
    {
        attackController.EndAttack();
    }

    private void Start()
    {
        Enemies = new List<Enemie>();
        attackController = GetComponent<PlayerAttackController>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Hp <= 0)
        {
            Die();
            return;
        }

        FindNearbyEnemies();
    }

    private void Die()
    {
        isDead = true;
        if (AnimatorController != null)
        {
            AnimatorController.SetTrigger("Die");
        }
        SceneManager.Instance.GameOver();
    }

    private void FindNearbyEnemies()
    {
        Enemies.Clear();
        Vector3 forward = transform.forward;
        float maxAngle = 90f;

        foreach (Enemie enemy in SceneManager.Instance.Enemies)
        {
            if (enemy == null) continue;

            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance > AttackRange) continue; 

            Vector3 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(forward, directionToEnemy);

            if (angle <= maxAngle)
            {
                Enemies.Add(enemy);
            }
        }
    }
}
