using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IInteractable
{
    public Enemy enemySO;
    
    [SerializeField] private int _satisfactionIncrease;
    
    public void NormalInteract()
    {
        GameLoopManager.Instance.Satisfaction += _satisfactionIncrease;
    }

    public void HardInteract()
    {
        GameLoopManager.Instance.Satisfaction += _satisfactionIncrease;
    }

    private void Start()
    {
        StartCoroutine(enemySO.InteractionsStarter(this));
    }
}
