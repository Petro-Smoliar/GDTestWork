using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SuperAttackButton : MonoBehaviour, IPointerDownHandler
{
    public float Cooldown = 2.0f;
    [SerializeField]
    private Image cooldownOverlay;
    private PlayerAttackController attackController;
    private Button button;
    private bool isCooldown = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (button.interactable == true && !isCooldown)
        {
            isCooldown = true;
            button.interactable = false;
            attackController.StartSuperAttackAnimation();
        }
    }
    public void StartCooldown()
    {
        if (button.IsActive())
        {
            StartCoroutine(RunCooldown());
        }
    }

    private IEnumerator RunCooldown()
    {
        float elapsedTime = 0f;
        button.interactable = false;
        while (elapsedTime < Cooldown)
        {
            if (!button.IsActive()) yield break;
            elapsedTime += Time.deltaTime;
            cooldownOverlay.fillAmount = elapsedTime / Cooldown;
            yield return null;
        }
        cooldownOverlay.fillAmount = 0;
        button.interactable = true;
        isCooldown = false;
    }

    private void Start() {
        button = GetComponent<Button>();
        attackController = SceneManager.Instance.Player.GetComponent<PlayerAttackController>();
    }

    private void Update() {
        if (SceneManager.Instance.Player.Enemies.Count == 0)
        {
            button.interactable = false;
        } else {
            button.interactable = true;
        }
    }
}