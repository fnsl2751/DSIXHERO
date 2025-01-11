using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

/// <summary>
/// PM구조에 사용하기 위한 PresenterManager의 기본 구조.
/// </summary>
public class BasePM : MonoBehaviour
{
    //자신에게 등록되어 있는 Presenter들을 List로 저장하고 있다.
    protected List<BaseP> PresenterList = new List<BaseP>();

    //자신의 PM 종류를 override Awake를 통해 지정한다.
    protected PM m_PM = PM.None;
    public PM PresenterManager
    {
        get { return m_PM; }
    }

    //UIManager에 본인을 등록한다.
    public virtual void Awake()
    {
        UIManager.I.AddPM(this);
    }

    /// <summary>
    /// Presenter용 Event를 전달하기 위한 함수. 받은 Event를 등록된 Presenter들에게 전달한다.
    /// </summary>
    /// <param name="PEvent"></param>
    public void SendEvent(PEvent PEvent)
    {
        for (int i = 0; i < PresenterList.Count; i++)
        {
            PresenterList[i].EventRecive(PEvent);
        }
    }

    // Presenter가 자신을 PM에 등록하거나 삭제하기 위한 함수.

    public void AddP(BaseP Presenter)
    {
        PresenterList.Add(Presenter);
    }

    public void DeleteP(BaseP Presenter)
    {
        PresenterList.Remove(Presenter);
    }


}
