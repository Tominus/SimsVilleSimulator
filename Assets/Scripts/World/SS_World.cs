using UnityEngine;

public class SS_World : SS_Singleton<SS_World>
{
    [SerializeField] SS_GameUI gameUI = null;
    [SerializeField] SS_DayCycle dayCycle = null;
    [SerializeField] SS_PlanningManager planningManager = new SS_PlanningManager();
    [SerializeField] SS_BuildingManager buildingManager = null;

    public bool IsValid => gameUI;
    public SS_GameUI GameUI => gameUI;
    public SS_DayCycle DayCycle => dayCycle;
    public SS_PlanningManager PlanningManager => planningManager;

    private void Start()
    {
        InitSub();
    }
    private void OnDestroy()
    {
        planningManager.OnDestroy();
    }

    void InitSub()
    {
        if (!IsValid) return;
        planningManager.OnEndInit += SetPlanningManager;
        planningManager.InitPlannings();
    }

    void SetPlanningManager(SS_PlanningManager _pm)
    {
        planningManager = _pm;
        Debug.Log("Planning manager init end");
    }
}