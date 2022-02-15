using System;
using UnityEngine;

public class SS_DayCycle : MonoBehaviour
{
    public event Action OnNight = null, OnDay = null, OnWeekEnd = null;
    public event Action<int> UpdateDay = null;
    public event Action<float> UpdateTime = null;

    [SerializeField] int currentDay = 0;
    [SerializeField] float currentHours = 0, daySpeed = 5, worldSpeedMultiplyer = 1;
    [SerializeField] Transform sunSocket = null;

    public bool IsValid => sunSocket;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        UpdateDayCycle();
    }
    private void OnDestroy()
    {
        OnNight = null;
        OnDay = null;
        OnWeekEnd = null;
        UpdateDay = null;
        UpdateTime = null;
    }

    void Init()
    {
        if (!IsValid) return;
        SS_World.Instance.GameUI.OnWorldSpeedChange += UpdateWorldSpeed;
    }
    void UpdateDayCycle()
    {
        if (!IsValid) return;

        //TODO
    }
    public void UpdateWorldSpeed(float _speed)
    {
        worldSpeedMultiplyer = _speed;
    }
}