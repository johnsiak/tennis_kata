namespace TennisKata.Logic;

public class TiebreakGame : IGame
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _pointsPlayerOne;
    private int _pointsPlayerTwo;

    public TiebreakGame(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        return $"{_pointsPlayerOne}-{_pointsPlayerTwo}";
    }

    public void PointWonBy(Player player)
    {
        if (player == _playerOne)
        {
            _pointsPlayerOne++;
            return;
        }

        if (player == _playerTwo)
        {
            _pointsPlayerTwo++;
        }
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