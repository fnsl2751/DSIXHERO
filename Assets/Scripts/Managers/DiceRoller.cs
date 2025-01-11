using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineCommons;

public class DiceRoller : Singleton<DiceRoller>
{
    public List<Dice> DiceBox;
    public int RollingFinishedDice = -1;

    public GameObject DicePrefab;


    public void ClearAllDices()
    {
        for(int i = 0; i < DiceBox.Count; i++)
        {
            Destroy(DiceBox[i].gameObject);
        }

        DiceBox.Clear();
    }


    public void AddDice(int[] m_DiceValues, int[] m_AttactBuffs, DiceType m_Type)
    {
        Dice NewDice = Instantiate(DicePrefab, this.transform).GetComponent<Dice>();
        NewDice.SetDice(m_DiceValues, m_AttactBuffs, m_Type);
        DiceBox.Add(NewDice);
    }
    public void AddDice(int[] m_DiceValues, DiceType m_Type)
    {
        int[] DefaultAttactBuff = new int[6] { 0, 0, 0, 0, 0, 0 };

        Dice NewDice = Instantiate(DicePrefab, this.transform).GetComponent<Dice>();
        NewDice.SetDice(m_DiceValues, DefaultAttactBuff, m_Type);
        DiceBox.Add(NewDice);
    }
    public void AddDice(DiceType m_Type = DiceType.None)
    {
        if (m_Type == DiceType.None) m_Type = DiceType.ActionDice;

        int[] DefaultDiceValues = new int[6] { 0, 0, 0, 0, 0, 0 };
        int[] DefaultAttactBuff = new int[6] { 0, 0, 0, 0, 0, 0 };

        switch (m_Type)
        {
            case DiceType.ActionDice:
                DefaultDiceValues = new int[6] { 1, 2, 3, 4, 5, 6 };
                break;
            case DiceType.AttackDice:
                DefaultDiceValues = new int[6] { 1, 1, 2, 2, 3, 3 };
                break;
            case DiceType.DefenceDice:
                DefaultDiceValues = new int[6] { 0, 1, 1, 2, 2, 3 };
                break;
        }

        Dice NewDice = Instantiate(DicePrefab, this.transform.localPosition, this.transform.localRotation, this.transform).GetComponent<Dice>();
        NewDice.SetDice(DefaultDiceValues, DefaultAttactBuff, m_Type);
        DiceBox.Add(NewDice);
    }



    public void RollDice()
    {
        RollingFinishedDice = DiceBox.Count;
        for (int i = 0; i < DiceBox.Count; i++)
        {
            DiceBox[i].Roll();
        }
    }

    public void RollFinished(Dice dice)
    {
        RollingFinishedDice--;

        if(RollingFinishedDice <= 0)
        {
            for (int i = 0; i < DiceBox.Count; i++)
            {
                Debug.Log(i + ": " + DiceBox[i].Value);
            }
        }
    }
}
