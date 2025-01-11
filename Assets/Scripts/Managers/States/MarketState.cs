using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class MarketState : BaseState
{
    public override void Init()
    {
        STATE = State.Market;
    }

    public override void Enter()
    {
        Debug.Log("State : MarketState Enter");
    }

    public override void Exit()
    {
        Debug.Log("State : MarketState Exit");
    }
}
