using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class TurnPlayState : BaseState
{
    public override void Init()
    {
        STATE = State.TurnPlay;
    }

    public override void Enter()
    {
        Debug.Log("State : TurnPlayState Enter");

        TurnController.I.PlayRound();
    }

    public override void Exit()
    {
        Debug.Log("State : TurnPlayState Exit");
    }
}
