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
}