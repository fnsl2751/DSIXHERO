using UnityEditor;
using UnityEngine;

public class ObjectAlignWindowViaVector : EditorWindow
{
    private GameObject baseObject;
    private bool GridByCount;
    private Vector3Int Count = new Vector3Int(1,1,1);
    private Vector3 spacing;

    [MenuItem("Tools/MapDesign/Object Align Via Vector3 Value")]
    private static void OpenWindow()
    {
        ObjectAlignWindowViaVector window = GetWindow<ObjectAlignWindowViaVector>();
        window.titleContent = new GUIContent("Object Align");
        window.Show();
    }

    private void OnGUI()
    {
        baseObject = EditorGUILayout.ObjectField("������ �� ������Ʈ", baseObject, typeof(GameObject), true) as GameObject;
        GridByCount = EditorGUILayout.Toggle("������ ���� ����", GridByCount);
        Count = EditorGUILayout.Vector3IntField("����", Count);
        spacing = EditorGUILayout.Vector3Field("����", spacing);

        if (GUILayout.Button("����"))
        {
            AlignObjects();
        }

        GUILayout.Label("������ �� ������Ʈ ������Ƽ�� �Ҵ��մϴ�.");
        GUILayout.Label("������ ���� ������ üũ�Ǿ� �ִٸ�");
        GUILayout.Label("�������� ������ ��ŭ�� ���� ���ο� ������Ʈ�� ���ĵ˴ϴ�.");
        GUILayout.Label("Scene���� ������ �� ������Ʈ�κ��� ���ݸ��� ������ ������Ʈ���� �����մϴ�.");
        GUILayout.Label("[����] ��ư�� ���� �����մϴ�.");
    }

    private void AlignObjects()
    {
        if (baseObject == null)
        {
            Debug.LogError("������ �� ������Ʈ�� ����");
            return;
        }

        GameObject[] selectedObjects = Selection.gameObjects;
        int objectCount = selectedObjects.Length;

        if (objectCount == 0)
        {
            Debug.LogError("���õ� ������Ʈ�� ����");
            return;
        }

        if (GridByCount && Count.x <= 0 || Count.y <= 0 || Count.z <= 0)
        {
            Debug.LogError("������ 1���� ���� �� ����.");
            return;
        }

        Undo.RegisterCompleteObjectUndo(selectedObjects, "Align Objects");

        if (GridByCount)
        {
            Vector3Int CellCount = new Vector3Int(1, 1, 1);

            for (int i = 1; i < objectCount + 1; i++)
            {
                GameObject obj = selectedObjects[i - 1];

                if (obj == baseObject)
                    continue;

                Undo.RecordObject(obj.transform, "Move Object");

                CellCount.x++;

                if(Count.x < CellCount.x)
                {
                    CellCount.x = 1;
                    CellCount.y++;
                }
                if(Count.y < CellCount.y)
                {
                    CellCount.y = 1;
                    CellCount.z++;
                }

                Vector3 BasePos = baseObject.transform.position;

                obj.transform.position = new Vector3(BasePos.x + ((CellCount.x - 1) * spacing.x), BasePos.y + ((CellCount.y - 1) * spacing.y), BasePos.z + ((CellCount.z - 1) * spacing.z));
            }
        }
        else
        {
            Vector3 currentPosition = baseObject.transform.position + spacing;

            for (int i = 0; i < objectCount; i++)
            {
                GameObject obj = selectedObjects[i];

                if (obj == baseObject)
                    continue;

                Undo.RecordObject(obj.transform, "Move Object");

                obj.transform.position = currentPosition;
                currentPosition += spacing;
            }
        }
    }
}