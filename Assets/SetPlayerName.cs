using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField name;

    public void SetName()
    {
        Debug.Log(name.text);
        GameLoopManager.Instance.PlayerName = name.text;
        Debug.Log(GameLoopManager.Instance.PlayerName);
    }
}
