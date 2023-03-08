using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class FloorGenerator : EditorWindow
{
    private Vector2Int size;
    private GameObject floorPrefab;
    private string objName;
    private Vector2 placeOffset;

    [MenuItem("Tools/FloorGenerator")]
    static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FloorGenerator));
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Object placing Tool ;)");
        objName = EditorGUILayout.TextField("Name: ", objName);
        size = EditorGUILayout.Vector2IntField("Size: ", size);
        placeOffset = EditorGUILayout.Vector2Field("Offset: ", placeOffset);

        floorPrefab = EditorGUILayout.ObjectField("PreFab: ", floorPrefab, typeof(GameObject), false) as GameObject;
        
        if(GUILayout.Button("Create"))
        {
            GameObject floor = new GameObject(objName);
            Debug.Log(size);
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    GameObject newtile = Instantiate(floorPrefab, floor.transform);
                    newtile.transform.position = new Vector3(i * placeOffset.x, 0, j * placeOffset.y);
                }
            }
        }
    }
}
