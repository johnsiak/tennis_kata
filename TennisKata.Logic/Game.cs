namespace TennisKata.Logic;

public class Game
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;

    public Game(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        return "Love-All";
    }
}
