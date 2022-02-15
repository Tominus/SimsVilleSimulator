using System;
using UnityEngine;
using UnityEngine.UI;

public class SS_GameUI : MonoBehaviour
{
    public event Action<float> OnWorldSpeedChange = null;

    [SerializeField] Slider gameSpeedSlider = null;
    [SerializeField] float baseWorldSpeed = 1, worldSpeedMultiplyer = 10;

    private void Start()
    {
        Init();
    }
    private void OnDestroy()
    {
        OnWorldSpeedChange = null;
    }

    void Init()
    {
        gameSpeedSlider.onValueChanged.AddListener((call) => 
        OnWorldSpeedChange?.Invoke(gameSpeedSlider.value * worldSpeedMultiplyer + baseWorldSpeed)
        );
    }
}