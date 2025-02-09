using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreInputScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        GameLoopManager.Instance.PlayerName = inputField.text;
        
        Debug.Log(GameLoopManager.Instance.PlayerName);
    }
}
