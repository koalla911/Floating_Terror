using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDash : RobotComponents
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 5f;

    private bool isDashing;
    private float dashTimer;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        if (isDashing)
        {
            if (dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                robotController.MovePosition(newPosition);
                dashTimer += Time.deltaTime;

            }

            else
            {
                StopDash();
            }

        }
    }

    private void Dash()
    {
        isDashing = true;
        dashTimer = 0f;
        robotController.NormalMovement = false;
        dashOrigin = transform.position;

        dashDestination = transform.position + (Vector3) robotController.CurrentMovement.normalized * dashDistance;

    }

    private void StopDash()
    {
        isDashing = false;
        robotController.NormalMovement = true;
        
    }
}
