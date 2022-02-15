using UnityEngine;

public class SS_PlanningManager
{
    [SerializeField] SS_Planning[] allPlanning = new SS_Planning[0];

    public SS_Planning[] AllPlanning => allPlanning;

    public void InitPlannings()
    {
        foreach (SS_Planning _planning in allPlanning)
        {
            _planning.Init();
        }
    }
}