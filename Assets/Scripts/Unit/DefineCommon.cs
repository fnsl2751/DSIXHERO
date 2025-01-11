using UnityEngine;

namespace DefineCommons
{
    // 기본적으로 사용하는 enum과 정의를 위한 클래스들을 미리 선언하고 사용하기 위한 공통 정의
    // using DefineCommons;를 통해 모든 정의를 사용할 수 있다.

    public enum State
    {
        None,
        RoundStart,
        TurnPlay,
        RoundEnd,
        Market,
    }

    public enum PEvent
    {
        None,
        Init,
        RoundStart_Enter,
        TurnPlay_Enter,
        RoundEnd_Enter,
        Market_Enter,
        RoundStart_Exit,
        TurnPlay_Exit,
        RoundEnd_Exit,
        Market_Exit,
        PlayCharaTurn,
    }

    public enum PM
    {
        None,
        FixedGUIPM,

    }

    public enum DiceType
    {
        None,
        ActionDice,
        AttackDice,
        DefenceDice
    }

    public enum Debuff
    {
        None,
        Fire,
        Ice,
        Light,
        Darkness,
    }
}
