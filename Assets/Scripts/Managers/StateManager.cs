using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DefineCommons;

public class StateManager : Singleton<StateManager>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    private State CurrentState;
    private State PreviousState;

    private List<BaseState> States = new List<BaseState>();

    public State CURRENTSTATE { get { return CurrentState; } }

    public void ChangeState(State NewState)
    {
        PreviousState = CurrentState;
        CurrentState = NewState;

        if (PreviousState != State.None)
        {
            States.Find(x => x.STATE == PreviousState).Exit();
            UIManager.I.SendPEvent((PEvent)Enum.Parse(typeof(PEvent), PreviousState.ToString() + "_Exit"));
        }

        States.Find(x => x.STATE == CurrentState).Enter();
        UIManager.I.SendPEvent((PEvent)Enum.Parse(typeof(PEvent), CurrentState.ToString() + "_Enter"));
    }

    public T GetStates<T>()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).GetComponent<T>() != null)
            {
                return this.transform.GetChild(i).GetComponent<T>();
            }
        }

        Debug.LogError("해당 State를 찾을 수 없습니다 : " + typeof(T).Name);
        return default(T);
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BaseState state = transform.GetChild(i).GetComponent<BaseState>();

            if (state != null)
            {
                States.Add(state);
                state.Init();
            }
        }

        UIManager.I.SendPEvent(PEvent.Init);
    }
}
