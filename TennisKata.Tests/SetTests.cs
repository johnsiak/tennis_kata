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

    [Fact]
    public void IsOverReturnsFalseDuringSet()
    {
        var set = new Set(_playerOne, _playerTwo);

        set.PointWonBy(_playerOne);

        Assert.False(set.IsOver());
    }

    [Fact]
    public void WinnerReturnsNullDuringSet()
    {
        var set = new Set(_playerOne, _playerTwo);

        set.PointWonBy(_playerOne);

        Assert.Null(set.Winner());
    }

private static void WinGame(Set set, Player player)
    {
        for (var i = 0; i < 4; i++)
        {
            set.PointWonBy(player);
        }
    }

    private static void WinGames(Set set, Player player, int games)
    {
        for (var i = 0; i < games; i++)
        {
            WinGame(set, player);
        }
    }

    [Fact]
    public void PlayerOneWinsSixGamesToThreeWinsTheSet()
    {
        var set = new Set(_playerOne, _playerTwo);

        WinGames(set, _playerOne, 3);
        WinGames(set, _playerTwo, 3);
        WinGames(set, _playerOne, 3);

        Assert.True(set.IsOver());
    }

    [Fact]
    public void SetAtSixFiveIsNotOver()
    {
        var set = new Set(_playerOne, _playerTwo);

        WinGames(set, _playerOne, 5);
        WinGames(set, _playerTwo, 5);
        WinGame(set, _playerOne);

        Assert.False(set.IsOver());
    }
}