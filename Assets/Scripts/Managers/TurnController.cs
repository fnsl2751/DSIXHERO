using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class TurnController : Singleton<TurnController>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public List<Character> PlayingTurn;
    protected Character currentTurnChara = null;
    protected int turnCount = 0;
    public int TurnCount
    {
        get { return turnCount; }
    }
    public Character CurrentTurnChara
    {
        get { return currentTurnChara; }
    }

    private void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            PlayingTurn.Add(this.transform.GetChild(i).GetComponent<Character>());
        }
    }

    public void PlayRound()
    {
        foreach(Character Chara in PlayingTurn)
        {
            Chara.IsTurnOver = false;
        }

        turnCount++;
        StartTurn();
    }

    public void StartTurn()
    {
        currentTurnChara = PlayingTurn.Find(x => x.IsTurnOver == false);
        UIManager.I.SendPEvent(PEvent.PlayCharaTurn, PM.FixedGUIPM);
    }

    public void EndTurn(Character chara)
    {
        chara.IsTurnOver = true;

        if(PlayingTurn.Find(x=> x.IsTurnOver == false))
        {
            StartTurn();
        }
        else
        {
            StateManager.I.ChangeState(State.TurnPlay);
        }
    }
}
