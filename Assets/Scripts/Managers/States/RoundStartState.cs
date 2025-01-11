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

        for(int i = 0; i < TurnController.I.PlayingTurn.Count; i++)
        {
            TurnController.I.PlayingTurn[i].GetTileOn = GameObject.FindObjectsOfType<Tile>()[Random.Range(0, 31)];
            TurnController.I.PlayingTurn[i].ForceMoveTileTo(TurnController.I.PlayingTurn[i].GetTileOn);
        }
    }

    public override void Exit()
    {
        Debug.Log("State : RoundStartState Exit");
    }
}
