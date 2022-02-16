using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public class SS_BuildingWindow : EditorWindow
{
    public event Action<List<SS_Schedule>> OnUpdateSchedule = null;

    #region Fields&Properties

    List<SS_Schedule> schedules = new List<SS_Schedule>();

    #endregion

    #region Methods

    private void OnGUI()
    {
        
        //DrawWindow
    }

    public void InitWindow(SS_Building _building)
    {
        
        Debug.Log($"{_building.name} Schedule Window debug");
        name = $"{_building.BuildingName} Schedule Window t";
        schedules = _building.Schedules;
    }

    #endregion
}
