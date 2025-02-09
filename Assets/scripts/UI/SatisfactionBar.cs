using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBar : MonoBehaviour
{
    private Image slider;
    private void Awake()
    {
        slider = GetComponent<Image>();
    }

    private void Update()
    {
        slider.fillAmount = GameLoopManager.Instance.Satisfaction / 100f;
    }
}
