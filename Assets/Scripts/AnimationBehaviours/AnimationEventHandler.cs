using UnityEngine;

public class AnimationEventHandler : MonoBehaviour /// Погана реализация
{
    private PlayerAttackController playerAttackController;
    private EnemyAttackController enemyAttackController;
    private const string TAG_PLAYER = "Player";

    public void ApplyDamageAttack()
    {
        if (gameObject.tag == TAG_PLAYER)
        {
            PlayerApplyDamage();
        } 
        else
        {
            EnemyApplyDamage();
        }
    }

    public void ApplyDamageSuperAttack()
    {
        if (gameObject.tag == TAG_PLAYER)
        {
            PlayerSuperApplyDamage();
        } 
    }

    private void PlayerApplyDamage()
    {
        playerAttackController.ApplyDamageAttack();
    }

    private void EnemyApplyDamage()
    {
        enemyAttackController.ApplyDamage();
    }

    private void PlayerSuperApplyDamage()
    {
        playerAttackController.ApplyDamageSuperAttack();
    }

    private void Start() {
        if (gameObject.tag == "Player")
        {
            playerAttackController = gameObject.GetComponent<PlayerAttackController>();
        }
        else
        {
            enemyAttackController = gameObject.GetComponent<EnemyAttackController>();
        }
    }
    
}