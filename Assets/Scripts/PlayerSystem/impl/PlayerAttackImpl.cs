using UnityEngine;

public class PlayerAttack : IAttackable
{
    private Player player = SceneManager.Instance.Player;

    public void AttemptAttack(float damage)
    {
        Enemie enemy = FindClosestEnemy();
        if (enemy != null)
        {
            Vector3 directionToFace = (enemy.transform.position - player.transform.position).normalized;
            player.transform.rotation = Quaternion.LookRotation(directionToFace);
            enemy.Hp -= damage;
        }
    }

    private Enemie FindClosestEnemy()
    {
        if (player.Enemies.Count == 0) return null;

        Enemie closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemie enemy in player.Enemies)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
