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
        return _pointsPlayerOne == PointsToWin || _pointsPlayerTwo == PointsToWin;
    }

    public Player? Winner()
    {
        return _pointsPlayerOne == PointsToWin ? _playerOne : _playerTwo;
    }
}