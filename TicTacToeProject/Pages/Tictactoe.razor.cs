using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using TicTacToeProject;
using TicTacToeProject.Shared;

namespace TicTacToeProject.Pages
{
    public partial class Tictactoe
    {
        public TicTacToeGame tictactoe;

        private string winMessage = "";

        private bool playerStartsFirst;

        private bool gameHasStarted = false; //TODO: this might need to be included

        public Shape[,] GameMatrix
        {
            get => tictactoe.GameMatrix;

            set
            {
                tictactoe.GameMatrix = value;
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

        public void RefreshPage()
        {
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
        }

        public void SetWinMessage()
        {
            if (tictactoe.WinMessage.Equals("win"))
            {
                ScoreTrackerService.Wins++;
                this.WinMessage = "You Won!";
            }
            else if (tictactoe.WinMessage.Equals("loss"))
            {
                ScoreTrackerService.Losses++;
                this.WinMessage = "AI Won!";
            }
            else if (tictactoe.WinMessage.Equals("tie"))
            {
                ScoreTrackerService.Ties++;
                this.WinMessage = "Game ended in a tie 👔";
            }
            else
            {
                this.WinMessage = String.Empty;
            }
        }

        protected override void OnInitialized()
        {
            tictactoe = new TicTacToeGame();
        }

        private void ChooseCross()
        {
            tictactoe.PlayerChosenShape = Shape.Cross;
            tictactoe.AiChosenShape = Shape.Circle;
        }

        private void ChooseCircle()
        {
            tictactoe.PlayerChosenShape = Shape.Circle;
            tictactoe.AiChosenShape = Shape.Cross;
        }

        public void SetGivenPos(int givenPos)
        {
            tictactoe.PositionToPlaceShape = givenPos;
            tictactoe.PlayerHasPlacedAShape = true;
        }

        public void StartGame()
        {
            this.playerStartsFirst = tictactoe.WhoStarts();
            this.gameHasStarted = true;
            if (!this.playerStartsFirst)
            {
                tictactoe.AiTurn();
            }
        }

        public void NextTurn()
        {
            tictactoe.TicTacToeRunTime();
        }

        public void SaveGameStateIfPossible()
        {
            if (WinMessage.Equals(String.Empty) && this.gameHasStarted)
            {
                GameStateService.SaveGameState
                (
                    new TicTacToeGame
                    (
                        tictactoe.PlayerHasPlacedAShape,
                        tictactoe.PlayerChosenShape,
                        tictactoe.AiChosenShape,
                        tictactoe.SaveUserPlacements,
                        tictactoe.SaveAiPlacements,
                        this.GameMatrix
                    )
                );
                // testing
                /*
                TicTacToeGame ttt = GameStateService.AcquireGameState();
                Console.WriteLine(ttt.PlayerHasPlacedAShape);
                Console.WriteLine(ttt.PlayerChosenShape);
                Console.WriteLine(ttt.AiChosenShape);
                Console.WriteLine(ttt.SaveUserPlacements);
                Console.WriteLine(ttt.SaveAiPlacements);
                Console.WriteLine(ttt.GameMatrix);
                */
            }




        }
    }

}