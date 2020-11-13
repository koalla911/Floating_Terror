using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;

    public Transform Target{ get; set; }

    public RobotMovement RobotMovement { get; set; }

    private void Awake()
    {
        RobotMovement = GetComponent<RobotMovement>();
    }

    private void Update()
    {
        currentState.EvaluateState(controller: this);
        

    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
        }
    }
    
}
