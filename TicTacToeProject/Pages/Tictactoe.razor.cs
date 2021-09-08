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

        private TicTacToeGame tictactoegame;

        private string winMessage = "";

        private bool playerStartsFirst;

        private bool gameHasStarted = false;

        private bool gameHasEnded = false;

        public Shape[,] GameMatrix
        {
            get => tictactoegame.GameMatrix;

            set
            {
                tictactoegame.GameMatrix = value;
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

        public void RefreshPageAndDeleteState()
        {
            GameStateService.RemoveGameState();
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
        }

        public void CheckGameEnding()
        {
            if (tictactoegame.WinMessage.Equals(GameEndings.win))
            {
                gameHasEnded = true;
                ScoreTrackerService.Wins++;
                this.WinMessage = "You Won!";
                tictactoegame.WinMessage = GameEndings.noEnd;
            }
            else if (tictactoegame.WinMessage.Equals(GameEndings.loss))
            {
                gameHasEnded = true;
                ScoreTrackerService.Losses++;
                this.WinMessage = "AI Won!";
                tictactoegame.WinMessage = GameEndings.noEnd;
            }
            else if (tictactoegame.WinMessage.Equals(GameEndings.tie))
            {
                ScoreTrackerService.Ties++;
                gameHasEnded = true;
                this.WinMessage = "Game ended in a tie 👔";
                tictactoegame.WinMessage = GameEndings.noEnd;
            }
            else
            {
                this.WinMessage = String.Empty;
            }
        }

        protected override void OnInitialized()
        {
            tictactoegame = new TicTacToeGame();
        }

        private void ChooseCross()
        {
            tictactoegame.PlayerChosenShape = Shape.Cross;
            tictactoegame.AiChosenShape = Shape.Circle;
        }

        private void ChooseCircle()
        {
            tictactoegame.PlayerChosenShape = Shape.Circle;
            tictactoegame.AiChosenShape = Shape.Cross;
        }

        public void SetGivenPos(int givenPos)
        {
            tictactoegame.PositionToPlaceShape = givenPos;
            tictactoegame.PlayerHasPlacedAShape = true;
        }

        public void StartGame()
        {
            this.playerStartsFirst = tictactoegame.WhoStarts();
            this.gameHasStarted = true;
            if (!this.playerStartsFirst)
            {
                tictactoegame.AiTurn();
            }
        }

        public void NextTurn()
        {
            tictactoegame.TicTacToeRunTime();
        }

        public void SaveGameStateIfPossible()
        {
            if (WinMessage.Equals(String.Empty) && this.gameHasStarted && (!gameHasEnded))
            {
                GameStateService.SaveGameState
                (
                    new TicTacToeGame
                    (
                        tictactoegame.PlayerHasPlacedAShape,
                        tictactoegame.PlayerChosenShape,
                        tictactoegame.AiChosenShape,
                        tictactoegame.SaveUserPlacements,
                        tictactoegame.SaveAiPlacements,
                        this.GameMatrix
                    )
                );
            }
        }
    }

}