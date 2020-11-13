using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFlip : RobotComponents
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }

    [SerializeField] private FlipMode flipMode = FlipMode.MovementDirection;
    [SerializeField] private float threshold = 0.1f;

    public bool FacingUp { get; set; }

    private void Awake()
    {
        FacingUp = true;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        FlipToMoveDirection();
    }    


    private void FlipToMoveDirection () 
    {
        if (Input.GetAxis("Horizontal") < 0) {
            
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            FacingUp = false;
                       
        }
        if (Input.GetAxis("Horizontal") > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            FacingUp = false;
            
        }
        if (Input.GetAxis("Vertical") < 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
            FacingUp = false;
            
        }
        if (Input.GetAxis("Vertical") > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            FacingUp = true;
            
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0) {
            
            transform.localRotation = Quaternion.Euler(0, 0, -45);
            FacingUp = false;
        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 45);
            FacingUp = false;
        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 135);
            FacingUp = false;
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0) {
            transform.localRotation = Quaternion.Euler(0, 0, -135);
            FacingUp = false;
        }

        
    } 
    
}
