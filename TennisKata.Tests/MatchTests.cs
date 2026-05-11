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
}