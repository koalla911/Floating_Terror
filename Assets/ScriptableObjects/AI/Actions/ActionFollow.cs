using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Follow", fileName = "ActionFollow")]
public class ActionFollow : AIAction
{
    public float minDistanceToFollow = 1f;
    public override void Act(StateController controller)
    {
        FollowTarget(controller);

    }

    private void FollowTarget(StateController controller)
    {
        if (controller.Target == null)
        {
            return;
        }
        
        //Follow Horizontal
        if (controller.transform.position.x < controller.Target.position.x)
        {
            controller.RobotMovement.SetHorizontal(1);
        }
        else 
        {
            controller.RobotMovement.SetHorizontal(-1);

        }

        //follow Vertical
        if (controller.transform.position.y < controller.Target.position.y)
        {
            controller.RobotMovement.SetVertical(1);
        }
        else 
        {
            controller.RobotMovement.SetVertical(-1);

        }

        //Stop if min Distance reached (Horizontal)
        if (Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < minDistanceToFollow)
        {
            controller.RobotMovement.SetHorizontal(0);
        }

        //Stop if min Distance reached (Vertical)
        if (Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < minDistanceToFollow)
        {
            controller.RobotMovement.SetVertical(0);
        }
   
    }
}

    
    
