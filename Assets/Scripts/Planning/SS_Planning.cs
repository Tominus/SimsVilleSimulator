using System;
using UnityEngine;

[Serializable]
public class SS_Planning
{
    [SerializeField] SS_DailyPlanning[] allDaily = new SS_DailyPlanning[0];
    [SerializeField] string name = "";

    int lastDayCount = -1;

    public SS_DailyPlanning[] AllDaily => allDaily;
    public string Name => name;

    public void Init()
    {
        foreach (SS_DailyPlanning _daily in allDaily)
        {
            _daily.Init();
        }
        SS_World.Instance.DayCycle.UpdateDay += DailyPlanningSub;
    }
    public void OnDestroy()
    {
        foreach (SS_DailyPlanning _daily in allDaily)
        {
            if (_daily == null) continue;
            _daily.OnDestroy();
        }
    }

    public void SetAllWeekDay() // for editor
    {
        int _day = 0;
        foreach (SS_DailyPlanning _daily in allDaily)
        {
            _daily.SetWeekDay(_day);
            _day++;
        }
    }
    public void DailyPlanningSub(int _currentDay)
    {
        if (_currentDay == lastDayCount)
        {
            Debug.LogError("DailyPlanningSub : _currentDay == lastDayCount");
            return;
        }
        DailyPlanningUnSub(lastDayCount);

        if (_currentDay < 0 || _currentDay > allDaily.Length - 1)
        {
            Debug.LogError("DailyPlanningSub : _currentDay out of bound");
            return;
        }
        allDaily[_currentDay].Sub();
        lastDayCount = _currentDay;
    }
    void DailyPlanningUnSub(int _lastDay)
    {
        if (_lastDay < 0 || _lastDay > allDaily.Length - 1) return;
        allDaily[_lastDay].UnSub();
    }
}