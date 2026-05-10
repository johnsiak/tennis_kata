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
        var lead = _pointsPlayerOne - _pointsPlayerTwo;

        if (_pointsPlayerOne >= PointsToWin && lead >= 2)
        {
            return true;
        }

        if (_pointsPlayerTwo >= PointsToWin && lead <= -2)
        {
            return true;
        }

        return false;
    }

    public Player? Winner()
    {
        var lead = _pointsPlayerOne - _pointsPlayerTwo;

        if (_pointsPlayerOne >= PointsToWin && lead >= 2)
        {
            return _playerOne;
        }

        if (_pointsPlayerTwo >= PointsToWin && lead <= -2)
        {
            return _playerTwo;
        }

        return null;
    }
}