using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private bool isPaused = false;

    private void Start()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void LoadScene()
    {
        Debug.Log("Loading Scene");
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isPaused);
        }
        
        Time.timeScale = isPaused ? 0f : 1f;
    }
}