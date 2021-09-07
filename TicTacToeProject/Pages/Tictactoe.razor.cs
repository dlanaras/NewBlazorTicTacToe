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
            get => tictactoe.WinMessage;

            set
            {
                tictactoe.WinMessage = value;
            }
        }

        public void RefreshPage()
        {
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
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

        /*public void SetGivenPos(int givenPos)
        {
            tictactoe.PositionToPlaceShape = givenPos;
            gms.GameMatrix = this.GameMatrix;
        }*/
    }

}