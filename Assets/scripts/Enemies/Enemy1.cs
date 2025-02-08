using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IInteractable 
{
    private bool _isInTrigger = false;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && _isInTrigger)
        {
            Interact();
        }
    }

    private void Update()
    {
        Debug.Log(_isInTrigger);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isInTrigger = true;
        }
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
