using TennisKata.Logic;

namespace TennisKata.Tests;

public class GameTests
{
    private readonly Player _playerOne = new Player("Rafa");
    private readonly Player _playerTwo = new Player("Roger");

    [Fact]
    public void GameScoreStartsAtLoveAll()
    {
        var game = new Game(_playerOne, _playerTwo);

        Assert.Equal("Love-All", game.GetScore());
    }
}