using UnityEngine;

public class SS_World : SS_Singleton<SS_World>
{
    [SerializeField] SS_GameUI gameUI = null;
    [SerializeField] SS_DayCycle dayCycle = null;
    [SerializeField] SS_PlanningManager planningManager = null;
    [SerializeField] SS_BuildingManager buildingManager = null;

    public bool IsValid => gameUI && dayCycle && buildingManager;
    public SS_GameUI GameUI => gameUI;
    public SS_DayCycle DayCycle => dayCycle;
    public SS_PlanningManager PlanningManager => planningManager;

    private void Start()
    {
        InitSub();
    }

    void InitSub()
    {
        if (!IsValid) return;
        //Recup le json load finish
        //planningManager.OnEndInit += SetPlanningManager; += dayCycle.Start
        planningManager.InitPlannings();
        dayCycle.SetCanStart(true);
    }

    void SetPlanningManager(SS_PlanningManager _pm)
    {
        planningManager = _pm;
        Debug.Log("Planning manager init end");
    }
}