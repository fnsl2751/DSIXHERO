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
        baseObject = EditorGUILayout.ObjectField("기준이 될 오브젝트", baseObject, typeof(GameObject), true) as GameObject;
        GridByCount = EditorGUILayout.Toggle("갯수에 따라 정렬", GridByCount);
        Count = EditorGUILayout.Vector3IntField("갯수", Count);
        spacing = EditorGUILayout.Vector3Field("간격", spacing);

        if (GUILayout.Button("정렬"))
        {
            AlignObjects();
        }

        GUILayout.Label("기준이 될 오브젝트 프로퍼티에 할당합니다.");
        GUILayout.Label("갯수에 따라 정렬이 체크되어 있다면");
        GUILayout.Label("갯수에서 지정한 만큼의 가로 세로에 오브젝트가 정렬됩니다.");
        GUILayout.Label("Scene에서 기준이 될 오브젝트로부터 간격마다 정렬할 오브젝트들을 선택합니다.");
        GUILayout.Label("[정렬] 버튼을 눌러 정렬합니다.");
    }

    private void AlignObjects()
    {
        if (baseObject == null)
        {
            Debug.LogError("기준이 될 오브젝트가 없음");
            return;
        }

        GameObject[] selectedObjects = Selection.gameObjects;
        int objectCount = selectedObjects.Length;

        if (objectCount == 0)
        {
            Debug.LogError("선택된 오브젝트가 없음");
            return;
        }

        if (GridByCount && Count.x <= 0 || Count.y <= 0 || Count.z <= 0)
        {
            Debug.LogError("갯수는 1보다 작을 수 없음.");
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