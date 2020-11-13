using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotComponents : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;

    protected RobotController robotController;
    protected RobotMovement robotMovement;
    protected RobotWeapon robotWeapon;
    protected RobotCharacter robotCharacter;


    protected virtual void Start()
    {
        robotController = GetComponent<RobotController>();
        robotCharacter = GetComponent<RobotCharacter>();
        robotWeapon = GetComponent<RobotWeapon>();
        robotMovement = GetComponent<RobotMovement>();
    }

    protected virtual void Update() 
    {

        HandleAbility();

    }

    protected virtual void HandleAbility() 
    {

        InternalInput();

    }

    protected virtual void HandleInput() 
    {

        

    }

    protected virtual void InternalInput() 
    {
        if (robotCharacter.CharacterType == RobotCharacter.CharacterTypes.Player)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

    }
}
