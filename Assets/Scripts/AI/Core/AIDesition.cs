using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDesition : ScriptableObject
{
    public abstract bool Decide(StateController controller);
    
}
