using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;
using System.Diagnostics;

public class UIManager : Singleton<UIManager>
{
    protected List<BasePM> m_PMList = new List<BasePM>();

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPM(BasePM PM)
    {
        m_PMList.Add(PM);
    }

    public void DeletePM(BasePM PM)
    {
        m_PMList.Remove(PM);
    }

    public List<BasePM> PMList
    {
        get { return m_PMList; }
    }

    public void SendPEvent(PEvent PresenterEvent, PM PresenterManager = PM.None)
    {
        StackTrace stackTrace = new StackTrace(true);

        UnityEngine.Debug.Log("UIEvent from : " + stackTrace.GetFrame(1).GetFileName() + " To " + PresenterEvent.ToString());

        for (int i = 0; i < m_PMList.Count; i++)
        {
            if (PresenterManager == PM.None || PresenterManager == m_PMList[i].PresenterManager)
            {
                m_PMList[i].SendEvent(PresenterEvent);
            }
        }
    }

    public void SendPEvent(PEvent PresenterEvent, PM PresenterManagerA, PM PresenterManagerB)
    {
        for (int i = 0; i < m_PMList.Count; i++)
        {
            if (PresenterManagerA == m_PMList[i].PresenterManager || PresenterManagerB == m_PMList[i].PresenterManager)
            {
                m_PMList[i].SendEvent(PresenterEvent);
            }
        }
    }

    public void SendPEvent(PEvent PresenterEvent, PM PresenterManagerA, PM PresenterManagerB, PM PresenterManagerC)
    {
        for (int i = 0; i < m_PMList.Count; i++)
        {
            if (PresenterManagerA == m_PMList[i].PresenterManager || PresenterManagerB == m_PMList[i].PresenterManager || PresenterManagerC == m_PMList[i].PresenterManager)
            {
                m_PMList[i].SendEvent(PresenterEvent);
            }
        }
    }

}