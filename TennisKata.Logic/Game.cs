namespace TennisKata.Logic;

public class Game
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _pointsPlayerOne;
    private int _pointsPlayerTwo;

    public Game(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        if (_pointsPlayerOne == _pointsPlayerTwo)
        {
            if (_pointsPlayerOne >= 3)
            {
                return "Deuce";
            }

            return $"{GetPointName(_pointsPlayerOne)}-All";
        }

        if (_pointsPlayerOne >= 4 || _pointsPlayerTwo >= 4)
        {
            var lead = _pointsPlayerOne - _pointsPlayerTwo;
            if (lead == 1)
            {
                return $"Advantage {_playerOne.Name}";
            }

            if (lead == -1)
            {
                return $"Advantage {_playerTwo.Name}";
            }
        }

        return $"{GetPointName(_pointsPlayerOne)}-{GetPointName(_pointsPlayerTwo)}";
    }

    private static string GetPointName(int points)
    {
        return points switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
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
        return Winner() is not null;
    }

    public Player? Winner()
    {
        var lead = _pointsPlayerOne - _pointsPlayerTwo;
        if (_pointsPlayerOne >= 4 && lead >= 2)
        {
            return _playerOne;
        }

        if (_pointsPlayerTwo >= 4 && lead <= -2)
        {
            return _playerTwo;
        }

        return null;
    }
}
