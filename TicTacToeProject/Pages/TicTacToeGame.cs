using System.Collections.Generic;
using System;

public class TicTacToeGame
{
    private string winMessage = String.Empty;

    private bool playerHasPlacedAShape = false;
    private Shape playerChosenShape = Shape.None;

    private Shape aiChosenShape;

    private List<int> saveUserPlacements = new List<int>();

    private List<int> saveAiPlacements = new List<int>();

    private bool playerStarts;

    public bool PlayerHasPlacedAShape
    {
        get => this.playerHasPlacedAShape;

        set
        {
            this.playerHasPlacedAShape = value;
        }
    }

    public bool PlayerStarts
    {
        get => this.playerStarts;

        set
        {
            this.playerStarts = value;
        }
    }

    public string WinMessage
    {
        get => this.winMessage;

        set
        {
            this.winMessage = value;
        }
    }

    public Shape[,] GameMatrix
    {
        get => this.gameMatrix;

        set
        {
            this.gameMatrix = value;
        }
    }

    private Shape[,] gameMatrix = new Shape[3, 3]
    {
{Shape.None, Shape.None, Shape.None},
{Shape.None, Shape.None, Shape.None},
{Shape.None, Shape.None, Shape.None}
    };

    private int positionToPlaceShape;

    public int PositionToPlaceShape
    {
        get => this.positionToPlaceShape;

        set
        {
            if (!value.Equals(null))
            {
                this.positionToPlaceShape = value;
            }
        }
    }

    public List<int> AvailablePos()
    {
        int i = 0;
        List<int> availableMoves = new List<int>();
        foreach (Shape shape in gameMatrix)
        {
            if (shape.Equals(Shape.None))
            {
                availableMoves.Add(i);
            }
            i++;
        }
        return availableMoves;
    }


    public void SetGivenPos(int givenPos)
    {
        this.PositionToPlaceShape = givenPos;

    }

    public bool WhoStarts()
    {
        Random rand = new Random();
        double decider = rand.NextDouble();
        if (decider > 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Shape AiChosenShape
    {
        get => this.aiChosenShape;

        set
        {
            this.aiChosenShape = value;
        }
    }

    public Shape PlayerChosenShape
    {
        get => this.playerChosenShape;
        set
        {
            this.playerChosenShape = value;
        }
    }

    public bool IsPositionAvailablePlayer()
    {
        if (this.AvailablePos().Contains(this.PositionToPlaceShape))
        {
            return true;
        }
        return false;
    }

    private string WhichRowToPlaceShape(int chosenPos)
    {
        if (chosenPos < 3)
        {
            return "first";
        }
        else if (chosenPos > 2 && chosenPos < 6)
        {
            return "second";
        }
        else if (chosenPos <= 8 && chosenPos > 5)
        {
            return "third";
        }
        return String.Empty;
    }

    public void PlaceShapeOnGivenPos(Shape shapeToPlace)
    {

        if (this.WhichRowToPlaceShape(this.PositionToPlaceShape).Equals("first"))
        {
            this.GameMatrix[0, this.PositionToPlaceShape] = shapeToPlace;
        }
        else if (this.WhichRowToPlaceShape(this.PositionToPlaceShape).Equals("second"))
        {
            int validSecondRowPos = this.PositionToPlaceShape - 3;
            this.GameMatrix[1, validSecondRowPos] = shapeToPlace;
        }
        else if (this.WhichRowToPlaceShape(this.PositionToPlaceShape).Equals("third"))
        {
            int validThirdRowPos = this.PositionToPlaceShape - 6;
            this.GameMatrix[2, validThirdRowPos] = shapeToPlace;
        }

    }

    private bool AiPlaceIfWinPosIsFree()
    {
        TicTacToeAiLogic ticTacToeAiLogic = new TicTacToeAiLogic(this.saveAiPlacements, this.saveUserPlacements);
        List<int> missingPositionsForWinOrBlockPlayer = ticTacToeAiLogic.AiPlacingProcess();
        foreach (int missingPosForWinOrBlockPlayer in missingPositionsForWinOrBlockPlayer)
        {
            if (this.AvailablePos().Contains(missingPosForWinOrBlockPlayer))
            {
                this.PositionToPlaceShape = missingPosForWinOrBlockPlayer;
                saveAiPlacements.Add(missingPosForWinOrBlockPlayer);
                this.PlaceShapeOnGivenPos(this.AiChosenShape);
                return true;
            }
        }
        return false;
    }


    private void AiDoRandomMove()
    {
        Random rand = new Random();
        int randMove = rand.Next(0, 8);
        while (!this.AvailablePos().Contains(randMove))
        {
            randMove = rand.Next(0, 8);
        }
        saveAiPlacements.Add(randMove);
        this.PositionToPlaceShape = randMove;
        this.PlaceShapeOnGivenPos(this.AiChosenShape);

    }

    public void TicTacToeRunTime()
    {

        if (FindOutWhoWon().Equals("noone") && (!this.AvailablePos().Count.Equals(0)))
        {
            this.PlayerTurn();
            this.CheckForEndOfGame();
            if (FindOutWhoWon().Equals("noone"))
            {
                this.AiTurn();
                this.CheckForEndOfGame();
            }
        }
        else if (this.AvailablePos().Count.Equals(0))
        {
            Console.WriteLine("(Main) availablepos = 0");
            this.WinMessage = "Game ended in a tie 👔";
        }
        Console.Write("Game ended");
    }



    public void AiTurn()
    {
        if (!this.AvailablePos().Count.Equals(0))
        {
            if (!this.AiPlaceIfWinPosIsFree())
            {
                this.AiDoRandomMove();
            }
        }
        else
        {
            Console.WriteLine("(Ai) availablepos = 0");
            this.WinMessage = "Game ended in a tie 👔";
        }
    }

    private void PlayerTurn()
    {
        if (!this.AvailablePos().Count.Equals(0))
        {
            if (this.IsPositionAvailablePlayer())
            {
                this.saveUserPlacements.Add(this.PositionToPlaceShape);
                this.PlaceShapeOnGivenPos(this.playerChosenShape);
            }
        }
        else
        {
            Console.WriteLine("(Player) availablepos = 0");
            this.WinMessage = "Game ended in a tie 👔";
        }
    }




    public string FindOutWhoWon()
    {
        string playerWinningDiagonaly = this.CheckForDiagonalGameEnding(saveUserPlacements, "player");
        string playerWinningHorizontaly = this.CheckForHorizontalGameEnding(saveUserPlacements, "player");
        string playerWinningVertically = this.CheckForVerticalGameEnding(saveUserPlacements, "player");

        string aiWinningDiagonaly = this.CheckForDiagonalGameEnding(saveAiPlacements, "ai");
        string aiWinningHorizontaly = this.CheckForHorizontalGameEnding(saveAiPlacements, "ai");
        string aiWinningVertically = this.CheckForVerticalGameEnding(saveAiPlacements, "ai");

        if (playerWinningDiagonaly.Equals("player") || playerWinningHorizontaly.Equals("player") ||
        playerWinningVertically.Equals("player"))
        {
            return "player";
        }
        else if (aiWinningDiagonaly.Equals("ai") || aiWinningHorizontaly.Equals("ai") || aiWinningVertically.Equals("ai"))
        {
            return "ai";
        }
        else
        {
            return "noone";
        }
    }

    public void CheckForEndOfGame()
    {
        if (FindOutWhoWon().Equals("player"))
        {
            winMessage = "You won!";
        }
        else if (FindOutWhoWon().Equals("ai"))
        {
            winMessage = "The AI won!";
        }
    }

    private string CheckForVerticalGameEnding(List<int> placements, string whoMadePlacements)
    {
        if (placements.Contains(2) && placements.Contains(5) && placements.Contains(8))
        {
            return whoMadePlacements;
        }
        else if (placements.Contains(1) && placements.Contains(4) && placements.Contains(7))
        {
            return whoMadePlacements;
        }
        else if (placements.Contains(0) && placements.Contains(3) && placements.Contains(6))
        {
            return whoMadePlacements;
        }
        else
        {
            return "noone";
        }
    }

    private string CheckForHorizontalGameEnding(List<int> placements, string whoMadePlacements)
    {
        if (placements.Contains(0) && placements.Contains(1) && placements.Contains(2))
        {
            return whoMadePlacements;
        }
        else if (placements.Contains(3) && placements.Contains(4) && placements.Contains(5))
        {
            return whoMadePlacements;
        }
        else if (placements.Contains(6) && placements.Contains(7) && placements.Contains(8))
        {
            return whoMadePlacements;
        }
        else
        {
            return "noone";
        }
    }

    private string CheckForDiagonalGameEnding(List<int> placements, string whoMadePlacements)
    {
        if (placements.Contains(0) && placements.Contains(4) && placements.Contains(8))
        {
            return whoMadePlacements;
        }
        else if (placements.Contains(6) && placements.Contains(4) && placements.Contains(2))
        {
            return whoMadePlacements;
        }
        else
        {
            return "noone";
        }
    }
}