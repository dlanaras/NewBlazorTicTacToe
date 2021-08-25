using System;
using System.Collections.Generic;

    public class TicTacToe
    {

        public TicTacToe(Shape shapeChosenForPlayer, Shape shapeChosenForAi)
        {
            this.PlayerChosenShape = shapeChosenForPlayer;
            this.AiChosenShape = shapeChosenForAi;
        }

        private TicTacToePreparations ticTacToePrep;
        private TicTacToeAiLogic ticTacToeAiLogic;
        private Shape playerChosenShape;
        private Shape aiChosenShape;

        public Shape AiChosenShape
        {
            get => aiChosenShape;

            set
            {
                this.aiChosenShape = value;
            }
        }
        public Shape PlayerChosenShape
        {
            get => playerChosenShape;

            set
            {
                this.playerChosenShape = value;
            }
        }

        public Shape[,] gameMatrix = new Shape[3, 3]
        {
            {Shape.None, Shape.None, Shape.None},
            {Shape.None, Shape.None, Shape.None},
            {Shape.None, Shape.None, Shape.None}
        };

        public Shape[,] GameMatrix
        {
            get => gameMatrix;

            set
            {
                this.gameMatrix = value;
            }
        }

        private List<int> saveUserPlacements = new List<int>();

        public List<int> SaveUserPlacements
        {
            get => saveUserPlacements;
        }

        private List<int> saveAiPlacements = new List<int>();

        public List<int> SaveAiPlacements
        {
            get => saveAiPlacements;
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


        private bool AiPlaceIfWinPosIsFree()
        {
            List<int> missingPositionsForWinOrBlockPlayer = ticTacToeAiLogic.AiPlacingProcess();
            foreach (int missingPosForWinOrBlockPlayer in missingPositionsForWinOrBlockPlayer)
            {
                if (this.AvailablePos().Contains(missingPosForWinOrBlockPlayer))
                {
                    SaveAiPlacements.Add(missingPosForWinOrBlockPlayer);
                    //this.PlaceShapeAccordingToRow(this.AiChosenShape, missingPosForWinOrBlockPlayer);
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
            SaveAiPlacements.Add(randMove);
            
            //this.PlaceShapeAccordingToRow(this.AiChosenShape, randMove);
        }





        public static string WhichRowToPlaceShape(int chosenPos)
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


        private void ListPlayerReadablePositions()
        {
            Console.WriteLine("The Positions that are available are: ");
            foreach (int num in (this.AvailablePos()))
            {
                Console.Write("  " + (num + 1) + "  ");
            }
        }


        public void PlayerTurn()
        {

            if (!this.AvailablePos().Count.Equals(0))
            {

                string chosenPos = Console.ReadLine();
                if (!chosenPos.Equals(String.Empty))
                {
                    int parsedChosenPos;
                    bool result = Int32.TryParse(chosenPos, out parsedChosenPos);
                    parsedChosenPos -= 1;
                    if (result)
                    {
                        if (this.AvailablePos().Contains(parsedChosenPos))
                        {
                            saveUserPlacements.Add(parsedChosenPos);
                            //this.PlaceShapeAccordingToRow(this.PlayerChosenShape, parsedChosenPos);
                        }
                        else
                        {
                            Console.WriteLine("That position isn't available, please choose another! ");
                            this.PlayerTurn();
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's not a valid input, please try again! ");
                        this.PlayerTurn();
                    }
                }
                else
                {
                    this.PlayerTurn();
                }
            }
            else
            {
                Console.WriteLine("Game has ended in a tie.");
                System.Environment.Exit(0);
            }
        }


        public void AiTurn()
        {

            if (!this.AvailablePos().Count.Equals(0))
            {
                Console.WriteLine("AI's turn: \n");
                if (!this.AiPlaceIfWinPosIsFree())
                {
                    this.AiDoRandomMove();
                }
            }
            else
            {
                Console.WriteLine("Game has ended in a tie.");
                System.Environment.Exit(0);
            }
        }





        private int CalculateCurrentPos(int x, int y)
        {
            return y * 3 + 1 + x;
        }


        public void CheckForEndOfGame()
        {
            if (FindOutWhoWon().Equals("player"))
            {
                Console.WriteLine("You won!");
                System.Environment.Exit(0);
            }
            else if (FindOutWhoWon().Equals("ai"))
            {
                Console.WriteLine("The AI Won");
                System.Environment.Exit(0);
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

        public string FindOutWhoWon()
        {
            string playerWinningDiagonaly = this.CheckForDiagonalGameEnding(SaveUserPlacements, "player");
            string playerWinningHorizontaly = this.CheckForHorizontalGameEnding(SaveUserPlacements, "player");
            string playerWinningVertically = this.CheckForVerticalGameEnding(SaveUserPlacements, "player");

            string aiWinningDiagonaly = this.CheckForDiagonalGameEnding(SaveAiPlacements, "ai");
            string aiWinningHorizontaly = this.CheckForHorizontalGameEnding(SaveAiPlacements, "ai");
            string aiWinningVertically = this.CheckForVerticalGameEnding(SaveAiPlacements, "ai");

            if (playerWinningDiagonaly.Equals("player") || playerWinningHorizontaly.Equals("player") || playerWinningVertically.Equals("player"))
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
    }
