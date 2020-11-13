using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : RobotComponents
{

    [SerializeField] private float rideSpeed = 6f;
    public float RideMoveSpeed { get; set; }

    protected override void Start()
    {
        base.Start();
        RideMoveSpeed = rideSpeed;

    }


    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
    }

    private void MoveCharacter() 
    {

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        Vector2 moveInput = movement;
        Vector2 movementNormalized = moveInput.normalized;
        Vector2 movementSpeed = movementNormalized * RideMoveSpeed;
        robotController.SetMovement(movementSpeed);

    }

    public void ResetSpeed()
    {
        RideMoveSpeed = rideSpeed;
    }

    public void SetHorizontal(float value)
    {
        horizontalInput = value;

    }

    public void SetVertical(float value)
    {
        verticalInput = value;

    }

    
}
