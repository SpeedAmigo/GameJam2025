using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager
{
    private static GameLoopManager _instance;

    public static GameLoopManager Instance
    {
        get
        {
            if(_instance == null)
                _instance = new GameLoopManager();
            
            return _instance;
        }
    }

    private int _satisfaction = 50;

    public int Satisfaction
    {
        get { return _satisfaction; }
        set { _satisfaction = value; }
    }
    

    public void EndGame()
    {
        Debug.Log("Game Over");
    }
}
