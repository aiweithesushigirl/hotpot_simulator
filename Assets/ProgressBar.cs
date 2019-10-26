﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    //Access this variable from your script or add proper function in this script 
    public float TotalCookingTime;
    public float minTime;
    public float maxTime;
    public Slider healthBar;
    private void Start()
    {
        minTime = 0f;
        healthBar = GetComponent<Slider>();
        healthBar.minValue = 0f;
    }
    void Update()
    {
        UpdateHealthBar();
        TotalCookingTime = Mathf.Clamp(TotalCookingTime, healthBar.minValue, healthBar.maxValue);
    }
    void UpdateHealthBar()
    {
        Debug.Log("aaaaaaaa" + healthBar.value);
        healthBar.value = TotalCookingTime;
    }
}