namespace TennisKata.Logic;

public class TiebreakGame : IGame
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;

    public TiebreakGame(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        return "0-0";
    }

    public void PointWonBy(Player player)
    {
    }

    public bool IsOver()
    {
        return false;
    }

    public Player? Winner()
    {
        return null;
    }
}