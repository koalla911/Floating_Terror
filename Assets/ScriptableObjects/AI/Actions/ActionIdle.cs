using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Actions/Idle", fileName = "ActionIdle")]
public class ActionIdle : AIAction
{
    public override void Act(StateController controller)
    {
        controller.RobotMovement.SetHorizontal(0);
        controller.RobotMovement.SetVertical(0);
        
    }
}
