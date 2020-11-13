using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRun : RobotComponents
{
    [SerializeField] private float runSpeed = 10f;

    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun();
        }
    }

    private void Run()
    {
        robotMovement.RideMoveSpeed = runSpeed;
    }

    private void StopRun()
    {
        robotMovement.ResetSpeed();
    }

}
