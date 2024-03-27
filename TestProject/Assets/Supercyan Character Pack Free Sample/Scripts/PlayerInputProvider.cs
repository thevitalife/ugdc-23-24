using UnityEngine;

public class PlayerInputProvider : MonoBehaviour, IMovementInputProvider
{
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    public Vector2 GetDirection()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 direction = cameraTransform.forward * v + cameraTransform.right * h;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        return new Vector2(direction.x, direction.z);
    }

    public bool IsJumping()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool IsWalking()
    {
        bool walk = Input.GetKey(KeyCode.LeftShift);
        return walk;
    }
}
