using System;
using UnityEngine;

public class SS_DayCycle : MonoBehaviour
{
    public event Action OnWeekEnd = null;
    public event Action<int> UpdateDay = null;
    public event Action<float> UpdateTime = null;

    [SerializeField] bool canStart = false;
    [SerializeField] int currentDay = 0;
    [SerializeField] float currentHours = 0, daySpeed = 5, worldSpeedMultiplyer = 1, dayDuration = 3600, currentTimeInHours = 0;
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
        if (!IsValid || !canStart) return;
        currentHours += Time.deltaTime * daySpeed * worldSpeedMultiplyer;
        if (currentHours > dayDuration)
        {
            currentHours = 0;
            currentDay++;
            if (currentDay > 6)
            {
                currentDay = 0;
                OnWeekEnd?.Invoke();
            }
            UpdateDay?.Invoke(currentDay);
        }
        RotateSun(currentHours / dayDuration);
        currentTimeInHours = (currentHours / dayDuration) * 24;
        UpdateTime?.Invoke(currentTimeInHours);
    }
    void RotateSun(float _ratio)
    {
        float _angle = _ratio * 360 * Mathf.Deg2Rad;

        float _x = Mathf.Cos(_angle);
        float _y = Mathf.Sin(_angle);
        float _z = 0;

        sunSocket.transform.position = new Vector3(_x, _y, _z);
        sunSocket.LookAt(Vector3.zero);
    }
    public void UpdateWorldSpeed(float _speed)
    {
        worldSpeedMultiplyer = _speed;
    }
    public void SetCanStart(bool _state)
    {
        canStart = _state;
        UpdateTime?.Invoke(currentTimeInHours);
        UpdateDay?.Invoke(currentDay);
    }
}