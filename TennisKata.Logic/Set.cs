namespace TennisKata.Logic;

public class Set
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;

    public Set(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        return "0-0";
    }
}