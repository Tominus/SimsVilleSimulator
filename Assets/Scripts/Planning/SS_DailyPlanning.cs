using System;
using UnityEngine;

[Serializable]
public class SS_DailyPlanning
{
    [SerializeField] SS_Task[] allTask = new SS_Task[6];

    [SerializeField] int weekDay = -1; //potentially saved

    public SS_Task[] AllTask => allTask;
    public int WeekDay => weekDay;

    public void Init()
    {
        SS_DayCycle _dayCycle = SS_World.Instance.DayCycle;
        if (!_dayCycle)
        {
            Debug.LogError("Init : _dayCycle == null");
            return;
        }
        foreach (SS_Task _task in allTask)
        {
            _task.Init(_dayCycle);
        }
    }
    public void OnDestroy()
    {
        foreach (SS_Task _task in allTask)
        {
            if (_task == null) continue;
            _task.OnDestroy();
        }
    }

    public void Sub()
    {
        SS_DayCycle _dayCycle = SS_World.Instance.DayCycle;
        if (!_dayCycle)
        {
            Debug.LogError("Sub : _dayCycle == null");
            return;
        }
        foreach (SS_Task _task in allTask)
        {
            _task.Sub(_dayCycle);
        }
    }
    public void UnSub()
    {
        SS_DayCycle _dayCycle = SS_World.Instance.DayCycle;
        if (!_dayCycle)
        {
            Debug.LogError("UnSub : _dayCycle == null");
            return;
        }
        foreach (SS_Task _task in allTask)
        {
            _task.UnSub(_dayCycle);
        }
    }
    public void SetWeekDay(int _weekDay)
    {
        weekDay = _weekDay;
    }
}