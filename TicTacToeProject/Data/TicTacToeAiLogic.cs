using System;
using System.Collections.Generic;

    class TicTacToeAiLogic
    {
        public TicTacToeAiLogic(List<int> aiPlacements, List<int> userPlacements)
        {
            this.SaveAiPlacements = aiPlacements;
            this.SaveUserPlacements = userPlacements;
        }

        private List<int> saveAiPlacements;

        public List<int> SaveAiPlacements
        {
            get => this.saveAiPlacements;
            set
            {
                this.saveAiPlacements = value;
            }
        }

        private List<int> saveUserPlacements;

        public List<int> SaveUserPlacements
        {
            get => this.saveUserPlacements;
            set
            {
                this.saveUserPlacements = value;
            }
        }

        public List<int> AiPlacingProcess()
        {
            List<int> missingPositionsForWinOrBlockPlayer = new List<int>();
            missingPositionsForWinOrBlockPlayer.AddRange(this.CheckIfAiIsCloseToWin());
            missingPositionsForWinOrBlockPlayer.AddRange(this.CheckIfPlayerIsCloseToWin());
            return missingPositionsForWinOrBlockPlayer;
        }

        private List<int> CheckIfAiIsCloseToWin()
        {
            return new List<int>() {IsCloseToDiagonalWin(this.SaveAiPlacements), IsCloseToVericalWin(this.SaveAiPlacements), IsCloseToHorizontalWin(this.SaveAiPlacements)};
        }

        private List<int> CheckIfPlayerIsCloseToWin()
        {
            return new List<int>() {IsCloseToDiagonalWin(this.SaveUserPlacements), IsCloseToVericalWin(this.SaveUserPlacements), IsCloseToHorizontalWin(this.SaveUserPlacements)};
        }

        private int IsCloseToHorizontalWin(List<int> placements)
        {
            for (int position = 0; position < 9; position++)
            {
                bool isOnFirstColumn = position % 3 == 0;
                bool isOnLastColumn = position == 2 || position == 5 || position == 8;
                if (placements.Contains(position) && placements.Contains(position + 1))
                {
                    if (isOnFirstColumn)
                    {
                        return position + 2;
                    }
                    else if (isOnLastColumn)
                    {
                        return position - 2;
                    }
                }
                else if (placements.Contains(position) && placements.Contains(position + 2))
                {
                    if (isOnFirstColumn)
                    {
                        return position + 1;
                    }
                }
            }
            return -1;
        }


        private int IsCloseToVericalWin(List<int> placements)
        {
            for (int position = 0; position < 7; position++)
            {
                if (position < 3)
                {
                    if (placements.Contains(position) && placements.Contains(position + 3))
                    {
                        return position + 6;
                    }
                    else if (placements.Contains(position) && placements.Contains(position + 6))
                    {
                        return position + 3;
                    }
                }
                else
                {
                    if (placements.Contains(position) && placements.Contains(position + 3))
                    {
                        return position - 3;
                    }
                }
            }
            return -1;
        }

        private int IsCloseToDiagonalWin(List<int> placements)
        {
            //TODO: convert to for loop if you so wish
            if (placements.Contains(0) && placements.Contains(4))
            {
                return 8;
            }
            else if (placements.Contains(4) && placements.Contains(8))
            {
                return 0;
            }
            else if (placements.Contains(2) && placements.Contains(4))
            {
                return 6;
            }
            else if (placements.Contains(4) && placements.Contains(6))
            {
                return 2;
            }
            else if (placements.Contains(2) && placements.Contains(6))
            {
                return 4;
            }
            else if (placements.Contains(0) && placements.Contains(8))
            {
                return 4;
            }
            return -1;
        }
    }
