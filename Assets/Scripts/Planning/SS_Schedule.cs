using UnityEngine;
using System;

[Serializable]
public class SS_Schedule
{
    [SerializeField, Range(0, 24)] int startTime = 0;
    [SerializeField, Range(0, 24)] int endTime = 0;

    public int StartTime => startTime;
    public int EndTime => endTime;
}
