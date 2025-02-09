using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreInputScript : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
