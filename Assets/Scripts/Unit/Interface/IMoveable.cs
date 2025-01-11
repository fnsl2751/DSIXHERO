using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public Tile GetTileOn { get; set; }
    public int MoveCount { get; set; }

    public bool IsMoveTileTo(Tile Goto);
    public void ForceMoveTileTo(Tile Goto);
}
