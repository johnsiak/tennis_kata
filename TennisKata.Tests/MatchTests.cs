using TennisKata.Logic;

namespace TennisKata.Tests;

public class MatchTests
{
    private readonly Player _playerOne = new Player("Rafa");
    private readonly Player _playerTwo = new Player("Roger");

    [Fact]
    public void NewMatchScoreDisplaysInitialSetScoreZeroZero()
    {
        var match = new Match(_playerOne, _playerTwo);

        Assert.Equal("0-0", match.GetScore());
    }

    private static void WinGame(Match match, Player player)
    {
        for (var i = 0; i < 4; i++)
        {
            match.PointWonBy(player);
        }
    }

    private static void WinGames(Match match, Player player, int games)
    {
        for (var i = 0; i < games; i++)
        {
            WinGame(match, player);
        }
    }

    [Fact]
    public void PlayerOneWinsASetMatchShowsCompletedSetScore()
    {
        var match = new Match(_playerOne, _playerTwo);

        WinGames(match, _playerOne, 5);
        WinGames(match, _playerTwo, 3);
        WinGame(match, _playerOne);

        Assert.Equal("6-3", match.GetScore());
    }

    [Fact]
    public void PlayerTwoWinsASetMatchShowsBothCompletedSetScores()
    {
        var match = new Match(_playerOne, _playerTwo);

        WinGames(match, _playerOne, 6);
        WinGames(match, _playerOne, 3);
        WinGames(match, _playerTwo, 6);

        Assert.Equal("6-0, 3-6", match.GetScore());
    }

    [Fact]
    public void MatchScoreIncludesCurrentSetScoreAlongsideCompletedSets()
    {
        var match = new Match(_playerOne, _playerTwo);

        WinGames(match, _playerOne, 6);
        WinGame(match, _playerOne);

        Assert.Equal("6-0, 1-0", match.GetScore());
    }

    [Fact]
    public void IsOverReturnsFalseDuringMatch()
    {
        var match = new Match(_playerOne, _playerTwo);

        match.PointWonBy(_playerOne);

        Assert.False(match.IsOver());
    }
}