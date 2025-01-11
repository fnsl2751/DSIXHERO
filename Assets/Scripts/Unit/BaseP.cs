using UnityEngine;
using DefineCommons;

/// <summary>
/// PM구조에 사용하기 위한 Presenter의 기본 구조.
/// </summary>
public abstract class BaseP : MonoBehaviour
{
    private BasePM PresenterManager;

    //부모가 PM이라면 자신의 담당 PM으로 저장하고 PM에도 본인을 등록한다.
    private void Awake()
    {
        if (GetComponentInParent<BasePM>() != null)
        {
            PresenterManager = GetComponentInParent<BasePM>();
        }

        PresenterManager.AddP(this);
    }

    /// <summary>
    /// Presenter용 Event를 받기 위한 함수. Switch문을 통해 사용할 Event만 구문을 작성하고 그 외에는 무시한다. <br/>
    /// PEvent를 통해서는 데이터를 이동시킬 수 없고 따라서 데이터는 외부에 저장하고 Presenter에서는 작동 명령이 내려왔을 때 스스로 데이터를 확인하고 데이터에 맞게 자신을 갱신한다.
    /// </summary>
    /// <param name="Event"></param>
    public abstract void EventRecive(PEvent Event);




}

