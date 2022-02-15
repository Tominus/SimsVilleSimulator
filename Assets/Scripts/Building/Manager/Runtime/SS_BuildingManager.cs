using UnityEngine;
using System;
using System.Collections.Generic;

public class SS_BuildingManager : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Buildings")] List<SS_Building> allBuildings = new List<SS_Building>();

    #endregion

    #region Methods

    public void RemoveBuilding(SS_Building _building)
    {
        if (!allBuildings.Contains(_building)) return;
        allBuildings.Remove(_building);
        DestroyImmediate(_building.gameObject);
    }
    public void RemoveBuilding(int _buildingIndex)
    {
        if (_buildingIndex > allBuildings.Count) return;
        DestroyImmediate(allBuildings[_buildingIndex].gameObject);
        allBuildings.RemoveAt(_buildingIndex);
    }

    public void CreateBuilding(SS_Building _prefab)
    {
        if (!_prefab) return;
        SS_Building _building = Instantiate(_prefab);
        allBuildings.Add(_building);
    }

    #endregion
}
