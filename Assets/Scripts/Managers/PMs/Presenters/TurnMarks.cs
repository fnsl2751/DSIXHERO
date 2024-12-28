using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DefineCommons;
using TMPro;

public class TurnMarks : BaseP
{
    public TextMeshProUGUI TurnCount;
    public TextMeshProUGUI TurnChara;

    private void Init()
    {

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
            case PEvent.TurnPlay_Enter:
                TurnCount.text = "Turn : " + TurnController.I.TurnCount + "/30";
                break;
            case PEvent.PlayCharaTurn:
                TurnChara.text = TurnController.I.CurrentTurnChara.gameObject.name + "'s Turn";
                break;
        }
    }
}
