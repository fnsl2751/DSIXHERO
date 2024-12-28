using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

/// <summary>
/// PM������ ����ϱ� ���� PresenterManager�� �⺻ ����.
/// </summary>
public class BasePM : MonoBehaviour
{
    //�ڽſ��� ��ϵǾ� �ִ� Presenter���� List�� �����ϰ� �ִ�.
    protected List<BaseP> PresenterList = new List<BaseP>();

    //�ڽ��� PM ������ override Awake�� ���� �����Ѵ�.
    protected PM m_PM = PM.None;
    public PM PresenterManager
    {
        get { return m_PM; }
    }

    //UIManager�� ������ ����Ѵ�.
    public virtual void Awake()
    {
        UIManager.I.AddPM(this);
    }

    /// <summary>
    /// Presenter�� Event�� �����ϱ� ���� �Լ�. ���� Event�� ��ϵ� Presenter�鿡�� �����Ѵ�.
    /// </summary>
    /// <param name="PEvent"></param>
    public void SendEvent(PEvent PEvent)
    {
        for (int i = 0; i < PresenterList.Count; i++)
        {
            PresenterList[i].EventRecive(PEvent);
        }
    }

    // Presenter�� �ڽ��� PM�� ����ϰų� �����ϱ� ���� �Լ�.

    public void AddP(BaseP Presenter)
    {
        PresenterList.Add(Presenter);
    }

    public void DeleteP(BaseP Presenter)
    {
        PresenterList.Remove(Presenter);
    }


}
