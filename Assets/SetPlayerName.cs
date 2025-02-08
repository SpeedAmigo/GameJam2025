using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField name;

    public void SetName()
    {
        GameLoopManager.Instance.PlayerName = name.text;
        SceneManager.LoadScene("Game");
    }
}
