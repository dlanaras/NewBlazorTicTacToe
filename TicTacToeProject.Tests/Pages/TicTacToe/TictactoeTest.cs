using System;
using Bunit;
using Bunit.TestDoubles;
using Xunit;
using Microsoft.Extensions.DependencyInjection;


namespace TicTacToeProject.Pages
{
    public class TictactoeTest : TestContext
    {

        [Fact]
        public void PlayerChoosingCrossLeadsToStartGame()
        {

            // Arrange
            var ctx = new TestContext();
            ctx.Services.AddSingleton<GameStateService>();
            ctx.Services.AddSingleton<ScoreTrackerService>();
            var cut = ctx.RenderComponent<Tictactoe>();

            // Act
            cut.Find("button.cross").Click();

            // Assert
            cut.Find(".startButton").MarkupMatches("<div class='startButton'><button class='btn btn-primary'>Start Game </button></div>");
        }


        [Fact]
        public void PlayerChoosingCircleLeadsToStartGame()
        {
            // Arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<GameStateService>();
            ctx.Services.AddSingleton<ScoreTrackerService>();
            var cut = ctx.RenderComponent<Tictactoe>();

            // Act - click button to increment counter
            cut.Find("button.circle").Click();

            // Assert
            cut.Find(".startButton").MarkupMatches("<div class='startButton'><button class='btn btn-primary'>Start Game </button></div>");
        }
    }
}
