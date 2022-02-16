using UnityEngine;
using UnityEditor;

using System;

[CustomEditor(typeof(SS_BuildingManager))]
public class SS_BuildingManagerEditor : SS_CustomTemplateEditor<SS_BuildingManager>
{
    #region Fields&Properties

    const string PREFABS_PATH = "Buildings";

    SerializedProperty allBuilding = null;
    SS_Building[] buildingPrefabs = null;

    SS_Building building = null;
    Color buildingColor = Color.white;
    string buildingName = "";
    int buildingType = 0;

    #endregion

    #region Methods

    protected override void OnEnable()
    {
        base.OnEnable();
        Tools.hidden = true;

        buildingPrefabs = Resources.LoadAll<SS_Building>(PREFABS_PATH);
        allBuilding = serializedObject.FindProperty("allBuildings");
    }

    private void OnDisable()
    {
        building = null;
        Tools.hidden = false;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        DrawPrefabGUI();
        DrawBuildingGUI();
        DrawCurrentBuildingGUI();
    }

    private void OnSceneGUI()
    {
        DrawCurrentBuildingSceneGUI();
    }

    #region Inspector
    void DrawPrefabGUI()
    {
        EditorGUILayout.Space();
        GUILayout.Label("Building Prefabs", GetLabelStyle(Color.white, 15, FontStyle.Bold));
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            //GUILayout.Box(PrefabUtility.GetIconForGameObject(buildingPrefabs[i].gameObject));

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"{buildingPrefabs[i].name}");
            bool _create = GUILayout.Button($"Create");
            if (_create)
                eTarget.CreateBuilding(buildingPrefabs[i]);

            EditorGUILayout.EndHorizontal();
        }
    }
    void DrawBuildingGUI()
    {
        int _max = allBuilding.arraySize;
        if (_max == 0) return;

        EditorGUILayout.Space();
        GUILayout.Label("Buildings", GetLabelStyle(Color.white, 15, FontStyle.Bold));

        for (int i = 0; i < _max; i++)
        {
            SS_Building _building =  eTarget.GetBuilding(i);
            SerializedObject _buildingProperty = new SerializedObject(_building);
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"{_buildingProperty.FindProperty("buildingName").stringValue}");

            bool _delete = GUILayout.Button("Delete");
            if (_delete)
            {
                eTarget.RemoveBuilding(i);
                building = null;
                _max--;
                i--;
            }

            bool _select = GUILayout.Button("Select");
            if (_select)
            {
                building = eTarget.GetBuilding(i);
                if (!building) break;
                buildingName = building.BuildingName;
                buildingColor = building.BuildingColor;
                buildingType = (int)building.BuildingType;
            }
            
            EditorGUILayout.EndHorizontal();
        }
    }
    void DrawCurrentBuildingGUI()
    {
        if (!building) return;

        SerializedObject _buildingProperty = new SerializedObject(building);
        SerializedProperty _bType = _buildingProperty.FindProperty("buildingType");
        SerializedProperty _bName = _buildingProperty.FindProperty("buildingName");
        SerializedProperty _bColor = _buildingProperty.FindProperty("buildingColor");
        SerializedProperty _bSchedules = _buildingProperty.FindProperty("schedules");

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Current building : {_bName.stringValue}", GetLabelStyle(Color.yellow, 15, FontStyle.Bold));

        buildingName = EditorGUILayout.TextField("Name :", buildingName);
        buildingType = (int)(SS_BuildingType)EditorGUILayout.EnumPopup("Type :", (SS_BuildingType)buildingType);
        buildingColor = EditorGUILayout.ColorField("Color :", buildingColor);

        for (int i = 0; i < _bSchedules.arraySize; i++)
        {

        }

        EditorGUILayout.Space();

        

        bool _done = GUILayout.Button("Done");
        if (_done)
        {
            _bName.stringValue = buildingName;
            building.gameObject.name = buildingName;
            _bType.enumValueIndex = buildingType;
            _bColor.colorValue = buildingColor;
            _buildingProperty.ApplyModifiedProperties();
            building.ApplyColor();
            building = null;
        }
    }

    #endregion

    #region Scene

    void DrawCurrentBuildingSceneGUI()
    {
        if (!building) return;

        building.transform.position = Handles.DoPositionHandle(building.transform.position, Quaternion.identity);
    }

    #endregion

    GUIStyle GetLabelStyle(Color _color, int _fontSize = 12, FontStyle _fontStyle = FontStyle.Normal)
    {
        GUIStyle _style = new GUIStyle();
        _style.normal.textColor = _color;
        _style.fontSize = _fontSize;
        _style.fontStyle = _fontStyle;
        _style.alignment = TextAnchor.MiddleCenter;
        return _style;
    }

    #endregion
}
