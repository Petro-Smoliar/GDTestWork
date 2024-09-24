using UnityEngine;

public class SuperAttackStateBehaviour : StateMachineBehaviour
{
    private readonly string TAG_PLAYER = "Player";

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (animator.gameObject.tag == TAG_PLAYER)
        {
            SceneManager.Instance.SuperAttackButton.GetComponent<SuperAttackButton>().StartCooldown();
            SceneManager.Instance.Player.EndAttack();
        }
    }
}