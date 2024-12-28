using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public Vector2Int Pos;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(Pos);
    }
}
