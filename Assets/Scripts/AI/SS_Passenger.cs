using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SS_Passenger : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] MeshRenderer render = null;
    [SerializeField] SS_Planning planning = null;

    public bool IsValid => agent && render && planning != null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        render = GetComponent<MeshRenderer>();
        if (!IsValid) return;
        /*
        foreach (var item in planning)
        {
            
            foreach ()
        }
         */
        //TODO Abo au gameUI
    }

    void SetTask(SS_Task _task)
    {
        //SS_Building _building = _task.Building;
        //MoveTo(_building.RallyPointSocket);
        //UpdateColor(_building.Color);
    }
    void MoveTo(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }
    void UpdateColor(Color _color)
    {
        render.material.color = _color;
    }
}