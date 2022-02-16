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

    public void InitWindow(List<SS_Schedule> _schedules)
    {
        schedules = _schedules;
    }

    #endregion
}
