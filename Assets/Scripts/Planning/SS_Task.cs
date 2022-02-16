using System;
using UnityEngine;

[Serializable]
public class SS_Task
{
    public event Action<SS_Task> OnTaskUpdate = null;

    [SerializeField] SS_Schedule schedule = new SS_Schedule();
    [SerializeField] SS_Building building = null;

    bool hasAlreadyUpdate = false;

    public SS_Building Building => building;

    public void Init(SS_DayCycle _dayCycle)
    {
        _dayCycle.OnWeekEnd += ResetTask;
    }
    public void OnDestroy()
    {
        OnTaskUpdate = null;
    }

    public void IsOpen(float _dayTime)
    {
        bool _state = _dayTime >= schedule.StartTime && _dayTime <= schedule.EndTime;
        if (!hasAlreadyUpdate && _state)
        {
            OnTaskUpdate?.Invoke(this);
            hasAlreadyUpdate = true;
        }
    }
    public void Sub(SS_DayCycle _dayCycle)
    {
        _dayCycle.UpdateTime += IsOpen;
    }
    public void UnSub(SS_DayCycle _dayCycle)
    {
        _dayCycle.UpdateTime -= IsOpen;
    }
    void ResetTask()
    {
        hasAlreadyUpdate = false;
    }
}