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
}