using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool buttonDown = false;
    private PlayerAttackController attackController;

    private void Start()
    {
        attackController = SceneManager.Instance.Player.GetComponent<PlayerAttackController>();
    }

    private void Update()
    {
        if (buttonDown) attackController.StartAttackAnimation();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }
}