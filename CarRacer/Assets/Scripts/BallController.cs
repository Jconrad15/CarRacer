using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 500f;
    private float jumpHeight = 30000f;
    private float groundDistance = 0.55f;
    private Vector3 jump;
    private readonly float jumpCoolDownLength = 0.2f;
    private float jumpCooldown;

    private Rigidbody rb;
    private int layerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpHeight, 0.0f);
        layerMask = 1 << 8;
    }

    private void Update()
    {
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

        //Debug.Log("Jump");
        rb.AddForce(Time.deltaTime * jump);
        jumpCooldown = jumpCoolDownLength;
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        /*
         Debug.DrawRay(
            transform.position,
            Vector3.down,
            Color.red,
            4);*/

        if (Physics.Raycast(ray, groundDistance, layerMask))
        {
            return true;
        }

        return false;
    }

}
