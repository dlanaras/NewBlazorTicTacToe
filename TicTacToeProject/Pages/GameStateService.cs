using System;

public class GameStateService
{

    private TicTacToeGame tictactoe;

    public TicTacToeGame TicTacToe
    {
        get => this.tictactoe;

        set
        {
            this.tictactoe = value;
        }
    }

    public void SaveGameState(TicTacToeGame ticTacToeGameState)
    {
        this.tictactoe = ticTacToeGameState;
    }

    public TicTacToeGame AcquireGameState()
    {
        //TODO: try catch for null reference exception
        return this.tictactoe;
    }

    public void RemoveGameState()
    {
        this.tictactoe = null;
    }

}