using UnityEngine;

public class PlayerMoveController : MonoBehaviour 
{
    [SerializeField]
    private float MoveSpeed = 5f;
    private IMovable movable;

    private void Start()
    {
        movable = new PlayerMovement(MoveSpeed);
    }

    private void Update() 
    {
        movable.Move(transform);
    }
}