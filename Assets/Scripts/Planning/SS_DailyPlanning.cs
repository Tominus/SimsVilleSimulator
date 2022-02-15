using System;
using UnityEngine;

public class SS_DailyPlanning
{
    [SerializeField] SS_Task[] allTask = new SS_Task[6];

    int weekDay = -1;

    public SS_Task[] AllTask => allTask;
    public int WeekDay => weekDay;

    public void Init()
    {
        SS_DayCycle _dayCycle = SS_World.Instance.DayCycle;
        if (!_dayCycle) return;
        foreach (SS_Task _task in allTask)
        {
            _task.Init(_dayCycle);
        }
    }
    public void Sub()
    {
        foreach (SS_Task _task in allTask)
        {
            _task.Sub();
        }
    }
    public void UnSub()
    {
        foreach (SS_Task _task in allTask)
        {
            _task.UnSub();
        }
    }
    public void SetWeekDay(int _weekDay)
    {
        weekDay = _weekDay;
    }
}