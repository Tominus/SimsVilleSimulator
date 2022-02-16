using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class SS_Building : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] SS_BuildingType buildingType = SS_BuildingType.NONE;
    [SerializeField] string buildingName = "Name";
    [SerializeField] Color buildingColor = Color.white;
    [SerializeField] Transform rallyPoint = null;

    [SerializeField, Header("Building Graphics")] Renderer buildingRenderer = null;

    [SerializeField, Header("Building Schedule")] List<SS_Schedule> schedules = new List<SS_Schedule>();

    public bool IsValid => rallyPoint && buildingRenderer;

    public Color BuildingColor => buildingColor;
    public string BuildingName => buildingName;
    public SS_BuildingType BuildingType => buildingType;
    public Transform RallyPoint => rallyPoint;
    public List<SS_Schedule> Schedules => schedules;

    #endregion

    #region Methods

    public bool IsOpen(float _dayTime)
    {
        return schedules.Where(s => _dayTime >= s.StartTime && _dayTime <= s.EndTime).ToList().Count > 0;
    }

    public void ApplyColor()
    {
        if (!IsValid) return;
        buildingRenderer.sharedMaterial.SetColor("_BaseColor", buildingColor);
    }

    #endregion
}
