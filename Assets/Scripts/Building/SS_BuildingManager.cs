using UnityEngine;
using System;
using System.Collections.Generic;

public class SS_BuildingManager : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Buildings")] List<SS_Building> allBuildings = new List<SS_Building>();

    [SerializeField, Header("Prefabs")] List<SS_Building> buildingPrefabs = new List<SS_Building>();

    #endregion

    #region Methods

    public void RemoveBuilding(SS_Building _building)
    {
        if (!allBuildings.Contains(_building)) return;
        allBuildings.Remove(_building);
        Destroy(_building.gameObject);
    }
    public void RemoveBuilding(int _buildingIndex)
    {
        if (_buildingIndex > allBuildings.Count) return;
        Destroy(allBuildings[_buildingIndex].gameObject);
        allBuildings.RemoveAt(_buildingIndex);
    }

    public void CreateBuilding(SS_Building _buildingPrefab)
    {
        if (!_buildingPrefab) return;
        SS_Building _building = Instantiate(_buildingPrefab);
        allBuildings.Add(_building);
    }
    public void CreateBuilding(int _prefabIndex)
    {
        if (_prefabIndex > buildingPrefabs.Count) return;
        SS_Building _building = Instantiate(buildingPrefabs[_prefabIndex]);
        allBuildings.Add(_building);
    }

    #endregion
}
