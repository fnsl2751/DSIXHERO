using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class RoundStartState : BaseState
{
    public override void Init() 
    {
        STATE = State.RoundStart;
    }

    public override void Enter()
    {
        Debug.Log("State : RoundStartState Enter");
    }

    public override void Exit()
    {
        Debug.Log("State : RoundStartState Exit");
    }
}
