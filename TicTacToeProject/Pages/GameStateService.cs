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
        if(!this.tictactoe.Equals(null))
        {
        return this.tictactoe;
        }
        throw new Exception("This is only temporary, will add a custom exception");
    }

    public void RemoveGameState()
    {
        this.tictactoe = null;
    }

}