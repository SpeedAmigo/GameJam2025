using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform setNickPanel;
    public void StartGame()
    {
        setNickPanel.gameObject.SetActive(true);
    }
}
