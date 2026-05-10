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
}