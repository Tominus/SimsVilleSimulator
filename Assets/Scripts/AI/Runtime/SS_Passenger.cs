using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(MeshRenderer))]
public class SS_Passenger : MonoBehaviour
{
    [SerializeField] SS_Planning planning = null;
    [SerializeField, Range(1, 10)] float worldSpeedMultiplyer = 10;
    [SerializeField] SS_NavAgentData agentData = new SS_NavAgentData();

    NavMeshAgent agent = null;
    MeshRenderer render = null;

    public bool IsValid => agent && render && planning != null;
    public SS_Planning Planning => planning;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        render = GetComponent<MeshRenderer>();
        if (!IsValid) return;

        SS_World.Instance.GameUI.OnWorldSpeedChange += ChangeMoveSpeed;
        InitAgentData();
        InitPlanningSub();
    }
    void InitAgentData()
    {
        agentData = new SS_NavAgentData(agent.speed, agent.angularSpeed, agent.acceleration);
    }
    void InitPlanningSub()
    {
        SS_DailyPlanning[] _dailyPlanning = planning.AllDaily;
        int _maxDaily = _dailyPlanning.Length;
        for (int i = 0; i < _maxDaily; i++)
        {
            SS_DailyPlanning _daily = _dailyPlanning[i];
            if (_daily == null) continue;

            SS_Task[] _allTask = _daily.AllTask;
            int _maxTask = _allTask.Length;
            for (int j = 0; j < _maxTask; j++)
            {
                SS_Task _task = _allTask[j];
                if (_task == null) continue;
                _task.OnTaskUpdate += SetTask;
            }
        }
    }

    void SetTask(SS_Task _task)
    {
        SS_Building _building = _task.Building;
        MoveTo(_building.RallyPoint.position);
        UpdateColor(_building.BuildingColor);
    }
    void MoveTo(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }
    void UpdateColor(Color _color)
    {
        render.material.color = _color;
    }
    void ChangeMoveSpeed(float _speed)
    {
        agent.speed = agentData.Speed + worldSpeedMultiplyer * _speed;
        agent.acceleration = agentData.Acceleration + worldSpeedMultiplyer * _speed;
        agent.angularSpeed = agentData.AngularSpeed + worldSpeedMultiplyer * _speed;
    }
    public void SetPlanning(SS_Planning _planning)
    {
        planning = _planning;
    }
}

[Serializable]
public struct SS_NavAgentData
{
    [SerializeField] float speed, angularSpeed, acceleration;

    public float Speed => speed;
    public float AngularSpeed => angularSpeed;
    public float Acceleration => acceleration;

    public SS_NavAgentData(float _speed, float _angularSpeed, float _acceleration)
    {
        speed = _speed;
        angularSpeed = _angularSpeed;
        acceleration = _acceleration;
    }
}