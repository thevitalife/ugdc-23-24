using UnityEngine;

public interface IMovementInputProvider
{
    Vector2 GetDirection();
    bool IsWalking();
    bool IsJumping();
}
