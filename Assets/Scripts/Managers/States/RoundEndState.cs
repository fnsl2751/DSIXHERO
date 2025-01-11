using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class RoundEndState : BaseState
{
    public override void Init()
    {
        STATE = State.RoundEnd;
    }

    public override void Enter()
    {
        Debug.Log("State : RoundEndState Enter");
    }

    public override void Exit()
    {
        Debug.Log("State : RoundEndState Exit");
    }
}
