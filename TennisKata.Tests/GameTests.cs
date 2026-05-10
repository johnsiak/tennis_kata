using TennisKata.Logic;

namespace TennisKata.Tests;

public class GameTests
{
    private readonly Player _playerOne = new Player("Rafa");
    private readonly Player _playerTwo = new Player("Roger");

    [Fact]
    public void PlayerOneWinsAPointScoreIsFifteenLove()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);

        Assert.Equal("Fifteen-Love", game.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsAPointScoreIsLoveFifteen()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerTwo);

        Assert.Equal("Love-Fifteen", game.GetScore());
    }

    [Fact]
    public void BothPlayersAtOnePointScoreIsFifteenAll()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);

        Assert.Equal("Fifteen-All", game.GetScore());
    }

    [Fact]
    public void PlayerOneAtTwoPointsPlayerTwoAtOnePointScoreIsThirtyFifteen()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);

        Assert.Equal("Thirty-Fifteen", game.GetScore());
    }

    [Fact]
    public void ScoreCanReachFortyLove()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);

        Assert.Equal("Forty-Love", game.GetScore());
    }

    [Fact]
    public void BothPlayersAtThreePointsScoreIsDeuce()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);

        Assert.Equal("Deuce", game.GetScore());
    }

    [Fact]
    public void PlayerOneWinsAPointAtDeuceScoreIsAdvantagePlayerOne()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerOne);

        Assert.Equal($"Advantage {_playerOne.Name}", game.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsAPointAtDeuceScoreIsAdvantagePlayerTwo()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);

        Assert.Equal($"Advantage {_playerTwo.Name}", game.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsAPointFromAdvantagePlayerOneReturnsToDeuce()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);

        Assert.Equal("Deuce", game.GetScore());
    }

    [Fact]
    public void PlayerOneWinsTwoConsecutivePointsFromDeuceWinsTheGame()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);

        Assert.True(game.IsOver());
        Assert.Equal(_playerOne, game.Winner());
    }

    [Fact]
    public void GameCanBeWonWithoutReachingDeuce()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);

        Assert.True(game.IsOver());
        Assert.Equal(_playerOne, game.Winner());
    }

    [Fact]
    public void IsOverReturnsFalseDuringPlay()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);

        Assert.False(game.IsOver());
    }

    [Fact]
    public void IsOverReturnsTrueAfterGameIsWon()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);

        Assert.True(game.IsOver());
    }

    [Fact]
    public void WinnerReturnsNullDuringPlay()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);

        Assert.Null(game.Winner());
    }

    [Fact]
    public void WinnerReturnsPlayerTwoAfterPlayerTwoWins()
    {
        var game = new Game(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerTwo);

        Assert.Equal(_playerTwo, game.Winner());
    }
}