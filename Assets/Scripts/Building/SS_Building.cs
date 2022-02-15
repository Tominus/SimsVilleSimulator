using UnityEngine;
using System;
using System.Collections.Generic;

public class SS_Building : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Building Settings")] SS_BuildingType buildingType = SS_BuildingType.NONE;
    [SerializeField] Color buildingColor = Color.white;
    [SerializeField] Transform rallyPoint = null;

    [SerializeField, Header("Building Schedule")] List<SS_Schedule> schedules = new List<SS_Schedule>();

    public bool IsValid => rallyPoint;

    public Transform RallyPoint => rallyPoint;
    public Vector3 RallyPosition => IsValid ? rallyPoint.position : Vector3.zero;

    #endregion

    #region Methods



    #endregion
}
