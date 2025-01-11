using UnityEngine;
using DefineCommons;

/// <summary>
/// FSM�� ���� �⺻ State ����. Init�� ������, Enter�� �ش� State�� ���Խ�, Exit�� �ش� State���� ����ÿ� �۵��Ѵ�.
/// ��� BaseState�� ��ӹ޴� State���� Init���� �� �ڱ� �ڽ��� STATE���� �����ϵ��� �����Ѵ�.
/// </summary>
public abstract class BaseState : MonoBehaviour
{
    public State STATE;

    public abstract void Init();

    public abstract void Enter();

    public abstract void Exit();
}
