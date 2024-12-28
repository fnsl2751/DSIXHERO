using UnityEditor;
using UnityEngine;

public class TileMapSet : EditorWindow
{
    private string[] Type = { "8*4 NormalMap", "8*3 WallBossMap"};
    private int selectedType;


    [MenuItem("Tools/MapDesign/MapTileSet")]
    private static void OpenWindow()
    {
        TileMapSet window = GetWindow<TileMapSet>();
        window.titleContent = new GUIContent("TileMap Setting");
        window.Show();
    }

    private void OnGUI()
    {
        selectedType = EditorGUILayout.Popup("�� Ÿ��", selectedType, Type);

        if (GUILayout.Button("�ڵ� ����"))
        {
            TileMapScriptpAttach();
        }

        GUILayout.Label("�ڵ����� ���õ� Ÿ�ϸʿ�");
        GUILayout.Label("��ũ��Ʈ�� �ڵ����� ���� �� �����մϴ�.");
    }

    private void TileMapScriptpAttach()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        int objectCount = selectedObjects.Length;

        if (objectCount == 0)
        {
            Debug.LogError("���õ� ������Ʈ�� ����");
            return;
        }

        Undo.RegisterCompleteObjectUndo(selectedObjects, "TileMap Setting");

        Vector3Int CellCount = new Vector3Int(1, 1, 1);
        Vector3Int Count = new Vector3Int(1, 1, 1);
        switch (selectedType)
        {
            case 0:
                Count = new Vector3Int(8, 4, 1);
                break;
            case 1:
                Count = new Vector3Int(8, 3, 1);
                break;
        }

        for (int i = 0; i < objectCount; i++)
        {
            if (selectedObjects[i].GetComponent<Tile>() == null)
            {
                selectedObjects[i].AddComponent<Tile>();
            }
            Tile newTile = selectedObjects[i].GetComponent<Tile>();

            if (i != 0) CellCount.x++;

            if (Count.x < CellCount.x)
            {
                CellCount.x = 1;
                CellCount.y++;
            }
            if (Count.y < CellCount.y)
            {
                CellCount.y = 1;
                CellCount.z++;
            }

            newTile.Pos = new Vector2Int(CellCount.x, CellCount.y);
        }
    }
}
