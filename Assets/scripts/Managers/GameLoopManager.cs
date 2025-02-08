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

    private int _currentRound = 1;

    public int CurrentRound
    {
        get { return _currentRound; }
        set { _currentRound = value; }
    }

    private int _enemiesToSpawn = 5;

    public int EnemiesToSpawn
    {
        get { return _enemiesToSpawn; }
        set { _enemiesToSpawn = value; }
    }

    private int _satisfaction = 50;
    public int Satisfaction
    {
        get { return _satisfaction; }
        set { _satisfaction = value; }
    }
    
    public void RoundEnd()
    {
        _currentRound++;
    }
}
