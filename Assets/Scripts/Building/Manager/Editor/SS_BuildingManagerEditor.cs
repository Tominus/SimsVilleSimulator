using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI;
using System;

[CustomEditor(typeof(SS_BuildingManager))]
public class SS_BuildingManagerEditor : SS_CustomTemplateEditor<SS_BuildingManager>
{
    #region Fields&Properties

    SS_Building[] buildingPrefabs = null;

    #endregion

    #region Methods

    protected override void OnEnable()
    {
        base.OnEnable();
        buildingPrefabs = Resources.LoadAll<SS_Building>("Buildings");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }



    #endregion
}
