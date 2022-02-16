using UnityEngine;
using UnityEditor;
using System;

public class SS_PassengerEditorWindow : EditorWindow
{
    public event Action<SS_Planning, int> OnPlanningSelected = null;
    public event Action OnGUIUpdate = null;

    SS_Planning[] allPlannings = null;
    SS_Planning aiPlanning = null;
    int count = 0;

    private void OnEnable()
    {
        InitAllPlanning();
        OnGUIUpdate += () =>
        {
            DrawAllPlanning();
        };
    }
    private void OnGUI()
    {
        OnGUIUpdate?.Invoke();
    }
    
    void InitAllPlanning()
    {
        SS_World _world = FindObjectOfType<SS_World>();
        if (!_world)
        {
            Debug.LogError("Missing World");
            return;
        }
        allPlannings = _world.PlanningManager.AllPlanning;
        count = allPlannings.Length;
    }
    public void InitAIPlanning(SS_Planning _aiPlanning)
    {
        aiPlanning = _aiPlanning;
    }

    void DrawAllPlanning()
    {
        GUILayout.BeginVertical();
        {
            GUILayout.Label($"Planning :", GUILayout.Width(300));
            for (int i = 0; i < count; i++)
            {
                SS_Planning _planning = allPlannings[i];
                if (_planning == null) return;
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label($"{_planning.Name}", GUILayout.Width(200));
                    bool _buttonPressed = GUILayout.Button("Select", GetGUIStyle(_planning));
                    if (_buttonPressed)
                    {
                        OnPlanningSelected?.Invoke(_planning, i);
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.EndVertical();
    }
    GUIStyle GetGUIStyle(SS_Planning _planning, FontStyle _font = FontStyle.Normal)
    {
        GUIStyle _style = new GUIStyle();        
        _style.normal.textColor = aiPlanning == _planning ? Color.green : Color.red;
        _style.fontStyle = _font;
        return _style;
    }
}