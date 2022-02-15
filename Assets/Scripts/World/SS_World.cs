using UnityEngine;

public class SS_World : SS_Singleton<SS_World>
{
    [SerializeField] SS_GameUI gameUI = null;
    [SerializeField] SS_DayCycle dayCycle = null;
    //[SerializeField] SS_PlanningManager planningManager = null;
    //[SerializeField] SS_BuildingManager buildingManager = null;

    public bool IsValid => gameUI;
    public SS_GameUI GameUI => gameUI;
    public SS_DayCycle DayCycle => dayCycle;

    private void Start()
    {
        InitSub();
    }

    void InitSub()
    {
        if (!IsValid) return;
        //planningManager.OnEnd += SetPlanningManager;
    }

    /*
    void SetPlanningManager(SS_PlanningManager _pm)
    {
        planningManager = _pm;
    }
     */
}