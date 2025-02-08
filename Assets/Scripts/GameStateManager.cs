public static class GameStateManager
{
    public static GameState CurrentGameState { get; private set; }
    public static GameState PreviousGameState {get; private set;}

    static GameStateManager()
    {
        CurrentGameState = GameState.InGame;
        PreviousGameState = GameState.None;
    }
    
    public static void ChangeState(GameState newState)
    {
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
    }
}
