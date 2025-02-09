using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    private string _playerName;

    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    private int _satisfaction = 50;
    public int Satisfaction
    {
        get { return _satisfaction; }
        set
        {
            _satisfaction = value;
            
            if (_satisfaction <= 0)
                EndGame();
        }
    }
    
    private int _score = 0;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    
    private List<IGameEndListener> _endListeners = new List<IGameEndListener>();
    
    public void RegisterListener(IGameEndListener listener)
    {
        _endListeners.Add(listener);
    }

    public void UnregisterListener(IGameEndListener listener)
    {
        _endListeners.Remove(listener);
    }

    void EndGame()
    {
        foreach (var listener in _endListeners)
        {
            listener.OnGameEnd();
        }
    }
}
