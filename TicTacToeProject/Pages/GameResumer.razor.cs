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
    public partial class GameResumer
    {
        private bool shouldBeResumed = false;

        private TicTacToeGame tictactoe;
        public void Resume()
        {
            tictactoe = GameStateService.AcquireGameState();
            shouldBeResumed = true;
        }

        public void NewGame()
        {
            GameStateService.RemoveGameState();
        }
    }
}