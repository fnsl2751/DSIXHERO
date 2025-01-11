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
            Debug.Log("이동 거리가 0입니다. 이동에 실패했습니다.");
            return false;
        }

        int Distance = Mathf.Abs(Goto.Pos.x - GetTileOn.Pos.x) + Mathf.Abs(Goto.Pos.y - GetTileOn.Pos.y);
        if (Distance > MoveCount)
        {
            Debug.Log("이동 거리가 " + Distance + "이지만 이동력이 " + MoveCount + "입니다. 이동에 실패했습니다.");
            return false;
        }

        GetTileOn = Goto;

        //임시로 순간이동함.
        this.transform.localPosition = new Vector3(GetTileOn.transform.localPosition.x, GetTileOn.transform.localPosition.y + 1, GetTileOn.transform.localPosition.z);
        return true;
    }
    public void ForceMoveTileTo(Tile Goto)
    {
        GetTileOn = Goto;

        //임시로 순간이동함.
        this.transform.localPosition = new Vector3(GetTileOn.transform.localPosition.x, GetTileOn.transform.localPosition.y + 1, GetTileOn.transform.localPosition.z);
    }

    public int ActiveDiceCount { get; set; }
    public List<Dice> DiceList { get; set; }
    public void RollActiveDice()
    {
        if(ActiveDiceCount < DiceList.Count)
        {
            //리스트에 있는 주사위 중에 랜덤으로 카운트만큼 굴리기
        }
        else if(ActiveDiceCount >= DiceList.Count)
        {
            //다이스 리스트에 있는 주사위부터 굴리고 모자란 주사위 만큼 일반 주사위 굴리기
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
