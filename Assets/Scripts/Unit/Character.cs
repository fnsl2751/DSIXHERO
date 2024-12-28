using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class Character : MonoBehaviour
{
    public bool IsTurnOver = false;
    public List<List<Debuff>> Debuffs;


    public virtual void DebuffEffect()
    {

    }
    public virtual void ActingDice()
    {

    }
    public virtual void UseSkill()
    {

    }
    public virtual void TurnEnd()
    {

    }
}
