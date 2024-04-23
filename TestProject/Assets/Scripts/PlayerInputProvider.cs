using UnityEngine;

public class PlayerInputProvider : MonoBehaviour, IMovementInputProvider
{
    [SerializeField] 
    private float targetPointDistance = 0.5f;

    [SerializeField] 
    private PlayerInteractor playerInteractor;
    
    private Transform cameraTransform;
    private Vector3 _targetPoint;
    private bool _targetPointMode;
    private Interactable _targetInteratable;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    public void SetTargetPoint(Vector3 point)
    {
        _targetPoint = point;
        _targetPointMode = true;
        _targetInteratable = null;
    }

    public void SetTargetInteractable(Interactable interactable)
    {
        SetTargetPoint(interactable.transform.position);
        _targetInteratable = interactable;
    }

    public Vector2 GetDirection()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 direction = cameraTransform.forward * v + cameraTransform.right * h;

        if (direction.sqrMagnitude > 0.001)
        {
            SwitchOffTargetMode();
        }
        else if (_targetPointMode)
        {
            Vector3 targetPointDir = _targetPoint - transform.position;
            targetPointDir.y = 0;
            if (targetPointDir.magnitude < targetPointDistance)
            {
                if (_targetInteratable)
                {
                    playerInteractor.Interact(_targetInteratable);
                }
                SwitchOffTargetMode();
            }
            else
            {
                direction = targetPointDir.normalized;
            }
        }
        
        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        return new Vector2(direction.x, direction.z);
    }

    private void SwitchOffTargetMode()
    {
        _targetPointMode = false;
        _targetInteratable = null;
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
