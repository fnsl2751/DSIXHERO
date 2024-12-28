using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DefineCommons;
using TMPro;

public class PlayerGUI : BaseP
{
    public Button TurnEnd;
    public TextMeshProUGUI CurrentMove;

    private void Init()
    {
        TurnEnd.onClick.AddListener(() =>
        {
            TurnController.I.EndTurn(TurnController.I.CurrentTurnChara);
        });
    }

    private void Enter()
    {

    }

    private void Exit()
    {

    }

    public override void EventRecive(PEvent Event)
    {
        switch (Event)
        {
            case PEvent.Init:
                Init();
                break;
        }
    }
}
