using TennisKata.Logic;

namespace TennisKata.Tests;

public class TiebreakGameTests
{
    private readonly Player _playerOne = new Player("Rafa");
    private readonly Player _playerTwo = new Player("Roger");

    [Fact]
    public void TiebreakScoreStartsAtZeroZero()
    {
        var game = new TiebreakGame(_playerOne, _playerTwo);

        Assert.Equal("0-0", game.GetScore());
    }

    [Fact]
    public void PlayerOneWinsAPointTiebreakScoreIsOneZero()
    {
        var game = new TiebreakGame(_playerOne, _playerTwo);

        game.PointWonBy(_playerOne);

        Assert.Equal("1-0", game.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsAPointTiebreakScoreIsZeroOne()
    {
        var game = new TiebreakGame(_playerOne, _playerTwo);

        game.PointWonBy(_playerTwo);

        Assert.Equal("0-1", game.GetScore());
    }

    [Fact]
    public void PlayerOneReachesSevenPointsLeadingByTwoWinsTheTiebreak()
    {
        var game = new TiebreakGame(_playerOne, _playerTwo);

        for (var i = 0; i < 5; i++) game.PointWonBy(_playerOne);
        for (var i = 0; i < 5; i++) game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerOne);
        game.PointWonBy(_playerOne);

        Assert.True(game.IsOver());
    }

    [Fact]
    public void TiebreakAtSevenSixIsNotOver()
    {
        var game = new TiebreakGame(_playerOne, _playerTwo);

        for (var i = 0; i < 6; i++) game.PointWonBy(_playerOne);
        for (var i = 0; i < 6; i++) game.PointWonBy(_playerTwo);
        game.PointWonBy(_playerOne);

        Assert.False(game.IsOver());
    }
}