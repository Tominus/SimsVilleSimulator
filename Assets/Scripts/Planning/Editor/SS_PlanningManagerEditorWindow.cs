using UnityEngine;
using UnityEditor;
using System;

public class SS_PlanningManagerEditorWindow : EditorWindow
{
    public event Action OnGUIUpdate = null;



    private void OnEnable()
    {
        
        OnGUIUpdate += () =>
        {
            
        };
    }
    private void OnGUI()
    {
        OnGUIUpdate?.Invoke();
    }


}