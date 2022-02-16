using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SS_PlanningManager : MonoBehaviour
{
    public event Action<SS_PlanningManager> OnEndInit = null;

    [SerializeField] SS_Planning[] allPlanning = new SS_Planning[0];

    public SS_Planning[] AllPlanning => allPlanning;

    public void InitPlannings()
    {
        foreach (SS_Planning _planning in allPlanning)
        {
            _planning.Init();
        }
        OnEndInit?.Invoke(this);
    }
    public void AddPlanning()
    {
        SS_Planning _newPlanning = new SS_Planning();
        _newPlanning.CreateAllWeekDay();

        List<SS_Planning> _allPlanning = allPlanning.ToList();
        _allPlanning.Add(_newPlanning);
        allPlanning = _allPlanning.ToArray();
    }
    private void OnDestroy()
    {
        foreach (SS_Planning _planning in allPlanning)
        {
            if (_planning == null) continue;
            _planning.OnDestroy();
        }
        OnEndInit = null;
    }
}