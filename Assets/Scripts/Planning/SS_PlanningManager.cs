using System;
using UnityEngine;

[Serializable]
public class SS_PlanningManager
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
    public void OnDestroy()
    {
        foreach (SS_Planning _planning in allPlanning)
        {
            if (_planning == null) continue;
            _planning.OnDestroy();
        }
        OnEndInit = null;
    }
}