using System;
using Bunit;
using Bunit.TestDoubles;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToeProject
{
    public class ScoreTrackerServiceTest : TestContext
    {

        [Fact]
        public void ScoreTrackerAppendsWins()
        {

            // Arrange
            ScoreTrackerService _ScoreTrackerService = new ScoreTrackerService();

            // Act
            _ScoreTrackerService.Wins++;

            // Assert
            Assert.True(_ScoreTrackerService.Wins.Equals(1));
        }

        [Fact]
        public void ScoreTrackerAppendsLosses()
        {

            // Arrange
            ScoreTrackerService _ScoreTrackerService = new ScoreTrackerService();

            // Act
            _ScoreTrackerService.Losses++;

            // Assert
            Assert.True(_ScoreTrackerService.Losses.Equals(1));
        }


        [Fact]
        public void ScoreTrackerAppendsTies()
        {

            // Arrange
            ScoreTrackerService _ScoreTrackerService = new ScoreTrackerService();

            // Act
            _ScoreTrackerService.Ties++;

            // Assert
            Assert.True(_ScoreTrackerService.Ties.Equals(1));
        }


    }
}
