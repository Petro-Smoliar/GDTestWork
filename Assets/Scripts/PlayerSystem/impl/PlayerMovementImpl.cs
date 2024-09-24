using UnityEngine;

public class PlayerMovement : IMovable
{
    private readonly float moveSpeed;

    public PlayerMovement(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public void Move(Transform transform)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            SceneManager.Instance.Player.AnimatorController.SetFloat("Speed", movement.magnitude);
        }
    }
}
