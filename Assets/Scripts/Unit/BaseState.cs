using UnityEngine;
using DefineCommons;

/// <summary>
/// FSM을 위한 기본 State 형태. Init은 생성시, Enter는 해당 State에 진입시, Exit는 해당 State에서 퇴장시에 작동한다.
/// 모든 BaseState를 상속받는 State들은 Init에서 꼭 자기 자신의 STATE값을 지정하도록 유의한다.
/// </summary>
public abstract class BaseState : MonoBehaviour
{
    public State STATE;

    public abstract void Init();

    public abstract void Enter();

    public abstract void Exit();
}
