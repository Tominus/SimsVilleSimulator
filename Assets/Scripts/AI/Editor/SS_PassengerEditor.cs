using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(SS_Passenger))]
public class SS_PassengerEditor : SS_CustomTemplateEditor<SS_Passenger>
{
    public event Action OnInspectorUpdate = null;

    SS_Planning aiPlanning = null;
    SS_PassengerEditorWindow window = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        InitPlanningList();

        OnInspectorUpdate += () =>
        {
            DrawDefaultProperties();
            serializedObject.ApplyModifiedProperties();
        };
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        OnInspectorUpdate?.Invoke();
    }

    void InitPlanningList()
    {
    }

    void DrawDefaultProperties()
    {
        aiPlanning = eTarget.Planning;

        SerializedProperty _speedMultiplyer = serializedObject.FindProperty("worldSpeedMultiplyer");
        GUILayout.BeginVertical();
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("Speed Multiplyer", GUILayout.Width(100));
                _speedMultiplyer.floatValue = GUILayout.HorizontalSlider(_speedMultiplyer.floatValue, 1, 10, null);
            }
            GUILayout.EndHorizontal();

            bool _buttonPressed = GUILayout.Button("Set Planning");
            if (_buttonPressed)
                OpenWindow();
        }
        GUILayout.EndVertical();
        GUILayout.Space(20);
    }

    void OpenWindow()
    {
        if (window) return;
        window = EditorWindow.CreateWindow<SS_PassengerEditorWindow>("Set Planning");
        window.InitAIPlanning(aiPlanning);
        window.OnPlanningSelected += SetAIPlanning;
    }
    void SetAIPlanning(SS_Planning _planning, int _index)
    {
        if (_planning == null)
        {
            Debug.LogError("no Planning updated");
            return;
        }
        eTarget.SetPlanning(_planning);
        eTarget.SetPlanningIndex(_index);
        window.Close();
    }
}