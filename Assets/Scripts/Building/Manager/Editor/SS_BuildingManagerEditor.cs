using UnityEngine;
using UnityEditor;

using System;

[CustomEditor(typeof(SS_BuildingManager))]
public class SS_BuildingManagerEditor : SS_CustomTemplateEditor<SS_BuildingManager>
{
    #region Fields&Properties

    const string PREFABS_PATH = "Buildings";

    SS_Building[] buildingPrefabs = null;

    SerializedProperty allBuilding = null;

    #endregion

    #region Methods

    protected override void OnEnable()
    {
        base.OnEnable();

        buildingPrefabs = Resources.LoadAll<SS_Building>(PREFABS_PATH);
        allBuilding = serializedObject.FindProperty("allBuildings");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawPrefabGUI();
        DrawBuildingGUI();
    }

    void DrawPrefabGUI()
    {
        EditorGUILayout.Space();
        GUILayout.Label("Building Prefabs :");
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"{buildingPrefabs[i].name}");
            bool _click = GUILayout.Button($"Create");
            if (_click)
                eTarget.CreateBuilding(buildingPrefabs[i]);

            EditorGUILayout.EndHorizontal();
        }
    }

    void DrawBuildingGUI()
    {
        int _max = allBuilding.arraySize;
        for (int i = 0; i < _max; i++)
        {
            SerializedProperty _building = allBuilding.GetArrayElementAtIndex(i);
            
            EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField($"{_building.FindPropertyRelative("buildingName").stringValue}");
            Debug.Log(_building.FindPropertyRelative("buildingName").stringValue);
            EditorGUILayout.LabelField($"Nom");
            bool _click = GUILayout.Button("Delete");
            if (_click)
                eTarget.RemoveBuilding(i);
            EditorGUILayout.EndHorizontal();
        }
        //eTarget.RemoveBuilding();
    }

    #endregion
}
