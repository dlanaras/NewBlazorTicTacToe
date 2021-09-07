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
    public partial class PrintGameMatrix
    {

        [Parameter]
        public Shape[,] GameMatrix { get; set; }

        private void SetGivenPos(int givenPos)
        {
            gms.GivenPos = givenPos;
        }
    }
}