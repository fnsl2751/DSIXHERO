using UnityEngine;

namespace DefineCommons
{
    // �⺻������ ����ϴ� enum�� ���Ǹ� ���� Ŭ�������� �̸� �����ϰ� ����ϱ� ���� ���� ����
    // using DefineCommons;�� ���� ��� ���Ǹ� ����� �� �ִ�.

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
