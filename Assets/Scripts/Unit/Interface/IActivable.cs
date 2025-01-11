using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivable
{
    public int ActiveDiceCount { get; set; }
    public List<Dice> DiceList { get; set; }
    public void RollActiveDice();

}
