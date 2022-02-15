using UnityEngine;
using System;

[Serializable]
public class SS_Schedule
{
    [SerializeField, Range(0, 24)] float startTime = 0;
    [SerializeField, Range(0, 24)] float endTime = 0;

    public float StartTime => startTime;
    public float EndTime => endTime;

    public bool IsOpen(float _dayTime)
    {
        return _dayTime >= startTime && _dayTime <= endTime;
    }
}
