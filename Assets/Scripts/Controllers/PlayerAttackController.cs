using UnityEngine;

public class PlayerAttackController : MonoBehaviour 
{
    [SerializeField]
    private float Damage = 1f;
    private bool onAttack = false;
    private IAttackable attackable;
    private Animator animator;
    
    private const string ATTACK_TRIGGER = "Attack";
    private const string SUPER_ATTACK_TRIGGER = "DoubleAttack";
    private const float multiplierSuper = 2;

    public void StartAttackAnimation()
    {
        if (!onAttack)
        {
            onAttack = true;
            animator.SetTrigger(ATTACK_TRIGGER);
        }
    }

    public void StartSuperAttackAnimation()
    {
        if (!onAttack)
        {
            onAttack = true;
            animator.SetTrigger(SUPER_ATTACK_TRIGGER);
        }
    }

    public void ApplyDamageAttack()
    {
        attackable.AttemptAttack(Damage);
    }

    public void ApplyDamageSuperAttack()
    {
        attackable.AttemptAttack(Damage * multiplierSuper);
    }

    public void EndAttack()
    {
        onAttack = false;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackable = new PlayerAttack();

    }
}