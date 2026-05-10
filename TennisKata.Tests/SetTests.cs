using TennisKata.Logic;

namespace TennisKata.Tests;

public class SetTests
{
    private readonly Player _playerOne = new Player("Rafa");
    private readonly Player _playerTwo = new Player("Roger");

    [Fact]
    public void NewSetScoreIsZeroZero()
    {
        var set = new Set(_playerOne, _playerTwo);

        Assert.Equal("0-0", set.GetScore());
    }

    [Fact]
    public void PlayerOneWinsAGameSetScoreIsOneZero()
    {
        var set = new Set(_playerOne, _playerTwo);

        set.PointWonBy(_playerOne);
        set.PointWonBy(_playerOne);
        set.PointWonBy(_playerOne);
        set.PointWonBy(_playerOne);

        Assert.Equal("1-0", set.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsAGameSetScoreIsZeroOne()
    {
        var set = new Set(_playerOne, _playerTwo);

        set.PointWonBy(_playerTwo);
        set.PointWonBy(_playerTwo);
        set.PointWonBy(_playerTwo);
        set.PointWonBy(_playerTwo);

        Assert.Equal("0-1", set.GetScore());
    }
}