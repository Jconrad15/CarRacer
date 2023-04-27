using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 400f;
    private float jumpHeight = 150f;
    private float groundDistance = 0.6f;
    private Vector3 jump;
    private readonly float jumpCoolDownLength = 0.2f;
    private float jumpCooldown = 0;

    private Rigidbody rb;
    private int layerMask;

    private bool movementDisabled;

    Vector3 savedVelocity;
    Vector3 savedAngularVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpHeight, 0.0f);
        layerMask = 1 << 8;

        RaceStarter rc = FindAnyObjectByType<RaceStarter>();
        rc.RegisterOnRaceStart(OnRaceStart);
        FindAnyObjectByType<Goal>().RegisterOnReachGoal(OnReachGoal);

        DisableMovement();
    }

    private void OnRaceStart()
    {
        EnableMovement();
    }

    private void OnReachGoal()
    {
        DisableMovement();
    }

    private void Update()
    {
        if (movementDisabled) { return; }

        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }

        CheckMovementInput();
        CheckJumpInput();
    }

    private void CheckMovementInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            moveHorizontal,
            0.0f,
            moveVertical);
        movement.Normalize();

        rb.AddForce(speed * Time.deltaTime * movement);
    }

    private void CheckJumpInput()
    {
        if (!Input.GetKeyDown(KeyCode.Space)
            || !IsGrounded()
            || jumpCooldown > 0)
        {
            return;
        }

        rb.AddForce(jump);
        jumpCooldown = jumpCoolDownLength;
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, groundDistance, layerMask))
        {
            return true;
        }

        return false;
    }

    public void DisableMovement()
    {
        savedVelocity = rb.velocity;
        savedAngularVelocity = rb.angularVelocity;
        rb.isKinematic = true;
        movementDisabled = true;
    }

    public void EnableMovement()
    {
        rb.isKinematic = false;
        rb.AddForce(savedVelocity, ForceMode.VelocityChange);
        rb.AddTorque(savedAngularVelocity, ForceMode.VelocityChange);
        movementDisabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Goal goal))
        {
            goal.OnPlayerCollideGoal();
        }
    }
}
