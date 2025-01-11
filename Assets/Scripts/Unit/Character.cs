using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class Character : MonoBehaviour, IMoveable, IDamageable, IActivable
{
    public struct DebuffCount
    {
        public Debuff Debuff;
        public int Count;
    }
    public bool IsTurnOver = false;
    public List<DebuffCount> Debuffs;

    public float Health { get; set; }
    public void GetDamage(float Damage)
    {
        Health -= Damage;
    }
    public void ActiveDebuff()
    {
        for (int i = 0; i < Debuffs.Count; i++)
        {
            if (Debuffs[i].Count <= 0)
            {
                continue;
            }
            switch (Debuffs[i].Debuff)
            {
                case Debuff.Fire:
                    break;
                case Debuff.Ice:
                    break;
                case Debuff.Light:
                    break;
                case Debuff.Darkness:
                    break;
                case Debuff.None:
                    break;
            }
            var val = Debuffs[i];
            val.Count--;
            Debuffs[i] = val;
        }
    }

    public Tile GetTileOn { get; set; }
    public int MoveCount { get; set; }

    public bool IsMoveTileTo(Tile Goto)
    {
        if(MoveCount <= 0)
        {
            Debug.Log("�̵� �Ÿ��� 0�Դϴ�. �̵��� �����߽��ϴ�.");
            return false;
        }

        int Distance = Mathf.Abs(Goto.Pos.x - GetTileOn.Pos.x) + Mathf.Abs(Goto.Pos.y - GetTileOn.Pos.y);
        if (Distance > MoveCount)
        {
            Debug.Log("�̵� �Ÿ��� " + Distance + "������ �̵����� " + MoveCount + "�Դϴ�. �̵��� �����߽��ϴ�.");
            return false;
        }

        GetTileOn = Goto;

        //�ӽ÷� �����̵���.
        this.transform.localPosition = new Vector3(GetTileOn.transform.localPosition.x, GetTileOn.transform.localPosition.y + 1, GetTileOn.transform.localPosition.z);
        return true;
    }
    public void ForceMoveTileTo(Tile Goto)
    {
        GetTileOn = Goto;

        //�ӽ÷� �����̵���.
        this.transform.localPosition = new Vector3(GetTileOn.transform.localPosition.x, GetTileOn.transform.localPosition.y + 1, GetTileOn.transform.localPosition.z);
    }

    public int ActiveDiceCount { get; set; }
    public List<Dice> DiceList { get; set; }
    public void RollActiveDice()
    {
        if(ActiveDiceCount < DiceList.Count)
        {
            //����Ʈ�� �ִ� �ֻ��� �߿� �������� ī��Ʈ��ŭ ������
        }
        else if(ActiveDiceCount >= DiceList.Count)
        {
            //���̽� ����Ʈ�� �ִ� �ֻ������� ������ ���ڶ� �ֻ��� ��ŭ �Ϲ� �ֻ��� ������
        }
    }

    public delegate void TurnPlaying();
    public TurnPlaying TurnEnd;

    private void Start()
    {
        
    }
    public void DebuffEffect()
    {
        ActiveDebuff();
    }
    public void ActingDice()
    {
        RollActiveDice();
    }
    public void UseSkill()
    {

    }
}
