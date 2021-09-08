using System;
using Bunit;
using Bunit.TestDoubles;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToeProject
{
    public class GameStateServiceTest : TestContext
    {

        [Fact]
        public void GameStateServiceReturnsATictactoegameObject()
        {

            // Arrange
            GameStateService _GameStateService = new GameStateService();
            TicTacToeGame tictactoeGame;

            // Act
            _GameStateService.SaveGameState(new TicTacToeGame());
            tictactoeGame = _GameStateService.AcquireGameState();

            // Assert
            Assert.True(tictactoeGame.GetType() == typeof(TicTacToeGame));
        }


    }
}
