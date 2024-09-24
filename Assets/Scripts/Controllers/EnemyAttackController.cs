using UnityEngine;

public class EnemyAttackController : MonoBehaviour {
    public float Damage;
    public float AtackSpeed;
    private Animator animatorController;
    private float lastAttackTime = 0;
    private Enemie enemie;
    private readonly string ATTACK_TRIGER = "Attack";

    public void ApplyDamage()
    {
        if (enemie.IsInAttackRange)
        {
            SceneManager.Instance.Player.Hp -= Damage;
        }
    }

    private void Start()
    {
        enemie = GetComponent<Enemie>();
        animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemie.IsInAttackRange && Time.time - lastAttackTime > AtackSpeed)
        {
            startAttackAnimation();
        }
    }

    private void startAttackAnimation()
    {
        lastAttackTime = Time.time;      
        animatorController.SetTrigger(ATTACK_TRIGER);
    }
}