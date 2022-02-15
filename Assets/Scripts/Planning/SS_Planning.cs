using UnityEngine;

public class SS_Planning
{
    [SerializeField] SS_DailyPlanning[] allDaily = new SS_DailyPlanning[0];
    [SerializeField] string name = "";

    int lastDayCount = -1;

    public SS_DailyPlanning[] AllDaily => allDaily;

    public void Init()
    {
        foreach (SS_DailyPlanning _daily in allDaily)
        {
            _daily.Init();
        }
        //TODO Init to DayCycle
    }
    public void DailyPlanningSub(int _currentDay)
    {
        if (_currentDay == lastDayCount) return;
        DailyPlanningUnSub(lastDayCount);

        foreach (SS_DailyPlanning _daily in allDaily)
        {
            _daily.Sub();
        }

        lastDayCount = _currentDay;
    }
    void DailyPlanningUnSub(int _lastDay)
    {
        if (_lastDay < allDaily.Length) return;

        foreach (SS_DailyPlanning _daily in allDaily)
        {
            _daily.UnSub();
        }
    }
}