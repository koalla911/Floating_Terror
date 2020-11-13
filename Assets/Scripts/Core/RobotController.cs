using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public Vector2 CurrentMovement { get; set; }
    public bool NormalMovement { get; set; }
    private Rigidbody2D rb;
    private Vector2 recoilMovement;


    private void Start()
    {
        NormalMovement = true;
        rb = GetComponent<Rigidbody2D>();
        
    }

    

    
    private void FixedUpdate() 
    {
        Recoil();

        if (NormalMovement)
        {
            MoveCharacter();
        }

    }

    private void MoveCharacter() {

        Vector2 currentMovePosition = rb.position + CurrentMovement * Time.fixedDeltaTime;
        rb.MovePosition(currentMovePosition);       


    }

    public void ApplyRecoil(Vector2 recoilDirection, float recoilForce)
    {
        recoilMovement = recoilDirection.normalized * recoilForce;

    }

    public void MovePosition(Vector2 newPosition)
    {
        rb.MovePosition(newPosition);
    }

    public void SetMovement(Vector2 newPosition) 
    {

        CurrentMovement = newPosition;

    }

    private void Recoil()
    {
        if (recoilMovement.magnitude > 0.1f)
        {
            rb.AddForce(recoilMovement);
        }

    }

    
}
