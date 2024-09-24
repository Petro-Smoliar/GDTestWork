using UnityEngine;

public class AttackStateBehaviour : StateMachineBehaviour 
{
    private const string TAG_PLAYER = "Player";

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        if (animator.gameObject.tag == TAG_PLAYER)
        {
            SceneManager.Instance.Player.EndAttack();
        }
    }
}