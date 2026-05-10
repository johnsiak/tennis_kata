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

    private const int PointsToWin = 7;

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
        if (_pointsPlayerOne == PointsToWin && _pointsPlayerOne - _pointsPlayerTwo >= 2)
        {
            return true;
        }

        if (_pointsPlayerTwo == PointsToWin && _pointsPlayerTwo - _pointsPlayerOne >= 2)
        {
            return true;
        }

        return false;
    }

    public Player? Winner()
    {
        return _pointsPlayerOne == PointsToWin ? _playerOne : _playerTwo;
    }
}