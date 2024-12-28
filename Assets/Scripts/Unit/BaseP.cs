using UnityEngine;
using DefineCommons;

/// <summary>
/// PM������ ����ϱ� ���� Presenter�� �⺻ ����.
/// </summary>
public abstract class BaseP : MonoBehaviour
{
    private BasePM PresenterManager;

    //�θ� PM�̶�� �ڽ��� ��� PM���� �����ϰ� PM���� ������ ����Ѵ�.
    private void Awake()
    {
        if (GetComponentInParent<BasePM>() != null)
        {
            PresenterManager = GetComponentInParent<BasePM>();
        }

        PresenterManager.AddP(this);
    }

    /// <summary>
    /// Presenter�� Event�� �ޱ� ���� �Լ�. Switch���� ���� ����� Event�� ������ �ۼ��ϰ� �� �ܿ��� �����Ѵ�. <br/>
    /// PEvent�� ���ؼ��� �����͸� �̵���ų �� ���� ���� �����ʹ� �ܺο� �����ϰ� Presenter������ �۵� ����� �������� �� ������ �����͸� Ȯ���ϰ� �����Ϳ� �°� �ڽ��� �����Ѵ�.
    /// </summary>
    /// <param name="Event"></param>
    public abstract void EventRecive(PEvent Event);




}

